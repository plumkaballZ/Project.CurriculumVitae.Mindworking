declare var require: any
var gulp = require('/gulp');
var del = require('del');

var paths = {
    scripts: ['Scripts/**/*.js', 'Scripts/**/*.ts', 'Scripts/**/*.map'],
};

gulp.task('clean', function () {
    return del(['wwwroot/Scripts/**/*']);
});

gulp.task('default', function () {
    gulp.src(paths.scripts).pipe(gulp.dest('wwwroot/Scripts'))
});