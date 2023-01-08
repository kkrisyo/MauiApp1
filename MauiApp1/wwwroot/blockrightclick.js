window.addEventListener('contextmenu', function (e) {
    console.log(e.srcElement.tagName);
    if (!isTextInput(e.srcElement)) {
        e.preventDefault();
    }
}, false);

function isTextInput(ele) {
    let tagName = ele.tagName;
    if (tagName === "INPUT" || tagName === "TEXTAREA") {
        return true
    }
    return false;
}