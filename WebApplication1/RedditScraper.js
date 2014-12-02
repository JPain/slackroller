//Not my proudest JS, but it works :P
//Run in console on a reddit list, you'll get what you need for SlackController's paydirt

if (!String.format) {
  String.format = function(format) {
    var args = Array.prototype.slice.call(arguments, 1);
    return format.replace(/{(\d+)}/g, function(match, number) { 
      return typeof args[number] != 'undefined'
        ? args[number] 
        : match
      ;
    });
  };
}

var arr = []
var results = []
var nodes = $("a.title")
var x = ""

for (i in nodes){
 if (nodes[i].href) { arr.push(nodes[i]) }
}

for (i in arr){
 results.push(String.format('new payload { imageURL = "{0}", text = "{1}"},\n', arr[i].href, arr[i].text))
}

for (i in results) {
 x = x + results[i]
}