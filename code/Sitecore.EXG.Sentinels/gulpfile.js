/// <vs SolutionOpened='watch' />
/// <binding ProjectOpened='watch' />
var gulp = require('gulp'),
  watch = require('gulp-watch'),
  filelog = require('gulp-filelog'),
  fileChanged = require('gulp-changed'),
  del = require('del'),
  vinylPaths = require('vinyl-paths'),
  R = require('ramda'),
  path = require('path'),
  csprojReader = require('./CsProjReader.js'),
  settingsReader = require('./SettingsReader.js'),
  fs = require('fs'),
  shell = require('gulp-shell');


var settings,
    csprojFiles,
    watcher;

function deploy (src) {
  return gulp
    .src(src, { base: settings.sourceWebDir })
    .pipe(fileChanged(settings.sitecoreDeployFolder))
    .pipe(filelog('DEPLOY'))
    .pipe(gulp.dest(settings.sitecoreDeployFolder));
}

function clean (src) {
  
  // In order to allow deleting files outside of current working dir,
  // we have to call the del method with the force option set to true.
  // Since that is the last parameter, the syntax gets a little odd.
  // We are composing a new function that has the options param set.   
  var forceDel = R.curry(del)(R.__, { force: true });
  
  return gulp
    .src(src, { read: false, base: settings.sitecoreDeployFolder })
    .pipe(filelog('DELETE'))
    .pipe(vinylPaths(forceDel));
}

gulp.task('clean', ['settings'], function () {
  
  var projectGlobs = settings.cleanList.map(function (projectGlob) {
      return path.join(settings.sitecoreDeployFolder, projectGlob);
    });

  return clean(projectGlobs);
});

gulp.task('deploy', ['readcsproj'], function () {
  return deploy(csprojFiles);
});

gulp.task('watch', ['readcsproj'], function () {
  watch(settings.sourceWebProj, { base: settings.sourceWebDir }, function () {
    csprojReader.read(settings.sourceWebProj, function (err, result) {
      if (err) {
        throw err;
      }

      var newProjFiles = result.map(function (entry) {
        return path.join(settings.sourceWebDir, entry);
      }),
      removedFiles = R.difference(csprojFiles, newProjFiles),
      addedFiles = R.difference(newProjFiles, csprojFiles);

      watcher.unwatch(removedFiles);
      watcher.add(addedFiles);
      
      clean(removedFiles.map(function (path) {
        return path.replace(settings.sourceWebDir, settings.sitecoreDeployFolder);
      }));

      deploy(addedFiles);
      
      csprojFiles = newProjFiles;
    });
  });

  watcher = watch(csprojFiles, { base: settings.sourceWebDir }, function (vinyl) {
    fs.stat(vinyl.path, function (err) {
      if (err) {
        console.log('INFO: File removed from project. Update your project file to remove it from your instance.\n' + vinyl.basename);
        return;
      }

      deploy(vinyl.path);
    });
  });
});

gulp.task('settings', function (done) {
  
  if (settings) {
    done();
    return;
  }

  settingsReader.read(function (value) {
    settings = value;
    done();
  });
});

gulp.task('readcsproj', ['settings'], function (done) {
  csprojReader.read(settings.sourceWebProj, function (err, result) {
    if (err) {
      throw err;
    }

    settings.dlllist.forEach(function(fileName) {
      result.push("bin/" + fileName);
    });
        
    csprojFiles = result.map(function (entry) {
      return path.join(settings.sourceWebDir, entry);
    });
    done();
  });
});

gulp.task('sync', ['clean'], function () {
  return gulp.start('deploy');
});

gulp.task('noop', function () {});

gulp.task('default', ['sync', 'watch']);

gulp.task('build', ['noop'], shell.task([
    'echo Starting build for the current branch',
    '..\\..\\tools\\BuildCurrentBranch.cmd'
]));

gulp.task('install', ['noop'], shell.task([
    'echo Starting build for the current branch',
    '..\\..\\tools\\InstallSitecore.cmd'
]));