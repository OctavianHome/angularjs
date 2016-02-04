app.filter('minRevenueFilter', function() {
    return function(item) {
        //var filtered = [];
        //for (var i = 0; i < items.length; i++) {
        //    var item = items[i];
        //    if (item.Revenue >= 200) {
        //        filtered.push(item);
        //    }
        //}
        //return filtered;

        if (item === undefined)
            return true;

        var objaa = item;
        return item.Revenue > 200;
    };
});

app.filter('makelowercase', function () {
    return function (item) {
        return item.toLowerCase();
    };
});

//app.filter('startsWithLetter', function () {
//    return function (items, letter) {
//        var filtered = [];
//        var letterMatch = new RegExp(letter, 'i');
//        for (var i = 0; i < items.length; i++) {
//            var item = items[i];
//            if (letterMatch.test(item.name.substring(0, 1))) {
//                filtered.push(item);
//            }
//        }
//        return filtered;
//    };
//});