var rngBase;

function spin() {
    rngBase = 12;
    spinning = false;
    myHtml = document.getElementsByTagName("body");
    myHtml[0].style.marginTop = "50px";
    myHtml[0].style.whiteSpace = "nowrap";
    myHtml[0].style.textAlign = "center";
    myHtml[0].style.transformOrigin = "50% 50%";
    degrees = 0;

    document.body.onkeyup = function (e) {
        if (e.keyCode === 192) {
            if (spinning) {
                window.clearInterval(interval);
                myHtml[0].style.transform = "rotate(0deg)";
                spinning = !spinning;
            }
            else {
                interval = setInterval(turn, 1);
                spinning = !spinning;
            }
        }
        else if (e.keyCode === 38) {
            console.log(rngBase += 5);
        }
        else if (e.keyCode === 40) {
            console.log(rngBase -= 5);
        }
    }
}
function rng(max) {
    return Math.floor(Math.random() * Math.floor(max));
}

function turn() {
    degrees += rngBase;
    myHtml[0].style.transform = "rotate(" + degrees % 360 + "deg)";
}