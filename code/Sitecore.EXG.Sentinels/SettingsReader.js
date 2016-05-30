var fs = require('fs'),
  path = require('path'),
  R = require('ramda'),
  xml2js = require('xml2js');

function readSettingsFile(projPath, cb) {
  var parser = new xml2js.Parser({ explicitArray: false });

  fs.readFile(projPath, 'utf-8', function(err, projFile) {
    if (err) {
      cb(err);
      return;
    }

    parser.parseString(projFile, function (err, result) {
      if (err) {
        cb(err);
        return;
      }

      var settings = result.Project.PropertyGroup
        .map(function (group) {
          return R.pick([
            'SourceWebPhysicalPath',
            'SourceWebVirtualPath',
            'SitecoreDeployFolder'
          ], group);
        })
        .reduce(function(prev, next) {
          return R.merge(prev, next);
        });

      cb(err, settings);
    });
  });  
}


module.exports = {
  read: function (cb) {
    var gulpSettings = JSON.parse(fs.readFileSync('gulpsettings.json').toString()),
      projectSettingsPath = gulpSettings.projectsettings,
      userPath = projectSettingsPath + '.user',
      projectSettingsDir = path.dirname(projectSettingsPath);

    readSettingsFile(projectSettingsPath, function (err, settings) {
      if (err) {
        throw err;
      }

      readSettingsFile(userPath, function (err, usersettings) {
        
          var mergedSettings = err ? settings : R.merge(settings, usersettings),
          sourceWebDir = path.join(projectSettingsDir, mergedSettings.SourceWebPhysicalPath);

        cb({
          sourceWebDir: sourceWebDir,
          sourceWebProj: path.join(sourceWebDir, mergedSettings.SourceWebVirtualPath),
          sitecoreDeployFolder: mergedSettings.SitecoreDeployFolder,
          cleanList: gulpSettings.cleanlist,
          dlllist: gulpSettings.dlllist
        });
      });
    });
  }
};