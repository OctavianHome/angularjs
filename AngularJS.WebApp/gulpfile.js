/// <binding />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

// include plug-ins
var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var del = require('del');
var dateFormat = require('dateformat');
var browserSync = require('browser-sync')

//gulp.task('default', function () {
//    // place code for your default task here
//});

var config = {
    //Include all js files but exclude any min.js files
    src: ['content/**/*.js', '!content/**/*.min.js']
}

//delete the output file(s)
gulp.task('clean', function () {
    //del is an async function and not a gulp plugin (just standard nodejs)
    //It returns a promise, so make sure you return that from this task function
    //  so gulp knows when the delete is complete
    return del(['content/*.min.js']);
});

// Combine and minify all files from the app folder
// This tasks depends on the clean task which means gulp will ensure that the 
// Clean task is completed before running the scripts task.
gulp.task('scripts', ['clean'], function () {

    var dateSufix = dateFormat(new Date(), "yyyymmddhhMMss");
    var bundleName = 'script-' + dateSufix + '.min.js';

    return gulp.src(config.src)
      .pipe(uglify())
      .pipe(concat(bundleName))
      .pipe(gulp.dest('content/'));
});

// create a task that ensures the `js` task is complete before
// reloading browsers
gulp.task('js-watch',[], browserSync.reload);

gulp.task('watchAngularJs', function () {
    //function reportChange(event) {
    //    console.log('Event type: ' + event.type); // added, changed, or deleted
    //    console.log('Event path: ' + event.path); // The path of the modified file
    //}

    //gulp.watch('content/angular/*.js', ['scripts', browserSync.reload]).on('change', reportChange);

    // Serve files from the root of this project
    browserSync.init({
        proxy: "http://localhost:38715"
    });

    gulp.watch('content/angular/*.js', ['js-watch']);
});

//Set a default tasks
gulp.task('default', ['scripts', 'watchAngularJs'], function () { });