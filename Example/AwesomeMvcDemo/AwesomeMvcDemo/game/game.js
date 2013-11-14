var running = true;
var arenaWidth = 620;
var arenaHeight = 450;
var time = 0;

$(function () {
    $('#startAgain').click(startGame);
    startGame();
});

function startGame() {
    $('#gameOver').hide();
    $('.agent').remove();
    running = true;
    var life = 100;
    var time = 0;
    $('#Life').html(life);
    $('.time').html(time);
    var cx = 300;
    var cy = 300;
    var ax = $('#arena').position().left;
    var ay = $('#arena').position().top;

    console.log('arena x ' + ax);
    console.log('arena y ' + ay);

    $(document).on('mousemove', function (e) {
        cx = e.pageX;
        cy = e.pageY;
    });

    //$('.agent').animate({ top: '+=100' }, 500);
    var i = 0;

    CreateAgent(0, 0);
    CreateAgent(100, 100);
    CreateAgent(150, 20);
    //CreateAgent(70, 200);
    //CreateAgent(200, 70);

    var creationTime = 2000;
    var p = setInterval(function () {
        if (running) {
            CreateAgent(200 * Math.random(), 100 * Math.random());
            if(creationTime > 300)
            creationTime -= 100;
        } else
            clearInterval(p);
    }, creationTime);

    var p1 = setInterval(function () {
        if (!running) {
            clearInterval(p1);
            return;
        }
        $('.agent').each(function () {
            var x = $(this).data('x');
            var y = $(this).data('y');

            var outside = false;
            if (cx > ax && cx < ax + arenaWidth
                && cy > ay && cy < ay + arenaHeight) {
            } else {
                outside = true;
            }

            if (cx > x && cx < x + 80 && cy > y && cy < y + 80 || outside) {

                if (!outside) {
                    $(this).toggle('explode', function() {
                        $(this).remove();
                        if (Math.random() > 0.3)
                            setTimeout(function () {
                                if (running) {
                                    CreateAgent(200 * Math.random(), 100 * Math.random());
                                }
                            }, 1000 * Math.random());
                    });
                    life -= 5;
                } else {
                    life--;
                }
                $('#LifeBar').addClass('damage');
                $('#LifeBar').removeClass('damage', 1000);

                if (life < 0) {
                    //game over
                    gameOver();
                    running = false;
                    life = 0;
                }

                $('#Life').html(life);
            }
        });
    }, 50);

    var pt = setInterval(function () {
        if (!running) {
            clearInterval(pt);
            return;
        }
        time++;
        $('.time').html(time);
    }, 1000);
}

function gameOver() {
    $('#gameOver').fadeIn();
}

function CreateAgent(ix, iy) {
    var agent = $('<div class="agent"></div>');
    $('#map').prepend(agent);
    
    var o = {
        stepx: 10,
        stepy: 30,
        agent: agent
    };

    agent.data("y", iy);
    agent.data("x", ix);

    agent.css('top', iy + 'px');
    agent.css('left', ix + 'px');

    go(o);

    function go(a) {
        if (!running) {
            return;
        }
        var r = Math.random();

        if (r > 0.8 && r < 0.82) {
            o.stepx += 30;
            if (o.stepx > 90) {
                a.agent.remove();
                return;
            }
        }

        if (r > 0.3 && r < 0.32) {
            o.stepy += 30;
            if (o.stepy > 90) {
                a.agent.remove();
                return;
            }
        }

        var x = a.agent.data("x");
        var y = a.agent.data("y");

        //choose direction
        if (x + a.stepx > 700 && a.stepx > 0 || x + a.stepx < 10 && a.stepx < 0) {
            a.stepx *= -1;
        }

        if (y + a.stepy > 500 && a.stepy > 0 || y + a.stepy < 10 && a.stepy < 0) {
            a.stepy *= -1;
        }

        makeStep(a);
    }

    function makeStep(a) {
        var x = a.agent.data("x");
        var y = a.agent.data("y");

        a.xstr = '+=' + a.stepx;
        a.ystr = '+=' + a.stepy;

        $(a.agent).animate({ left: a.xstr + 'px', top: a.ystr + 'px' }, 150, function () {

            x += a.stepx;
            y += a.stepy;

            agent.data("y", y);
            agent.data("x", x);

            go(a);
        });
    }

    //start moving;
}