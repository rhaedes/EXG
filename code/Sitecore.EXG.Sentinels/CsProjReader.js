var fs = require('fs'),
  path = require('path'),
  xml2js = require('xml2js'),
  R = require('ramda');

var parser = new xml2js.Parser({ explicitArray: false });

module.exports = {
  read: function (projPath, cb) {
    var csProjFile = fs.readFileSync(projPath);

    parser.parseString(csProjFile.toString(), function (err, result) {
      if (err) {
        cb(err, result);
      }

      var contentFiles = result.Project.ItemGroup
        .map(function (group) {
          return R.pick(['Content'], group);
        })
        .reduce(function(prev, next) {
          var prevList = prev.Content || [],
            nextList = next.Content || [];
          
          return { Content: prevList.concat(nextList) };
        })
        .Content
        .map(function (entry) {
          return entry.$.Include;
        })
        .map(function(entry) {
          var baseName = path.basename(entry);
          var firstLetter = baseName[0];
          
          return entry.replace(baseName, baseName.replace(firstLetter, "[" + firstLetter + "]"));
        });
      
      cb(err, contentFiles);
    });
  }
};