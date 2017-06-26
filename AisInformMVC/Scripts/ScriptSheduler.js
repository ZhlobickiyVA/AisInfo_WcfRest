
function RefreshData(rowBut) {

    var but = $('[name=ButValue' + rowBut + ']');
    var Sum = 0;
    for (var i = 0; i < but.length; i++) {
        var butItem = $(but[i]);
        Sum = Sum + +butItem.text();
        if (butItem.data('typework') == '1') butItem.addClass('combination');
        else butItem.removeClass('combination');
    }
    $('#CountHours' + rowBut).text(+Sum);




}





$(function () {
    $("[data-toggle='tooltip']").tooltip();
});
//$('#myModal').modal();
//alert($('#but'));

$('.buttonDay')
    .bind('mousedown'
    , function (event) {
        event.stopPropagation();

        if (event.which == 1) {

            var target = $(event.target);
            var maxtime = target.data('maxtime');
            var rowBut = target.data('row');
            var valBut = target.text();
            var idBut = target.data('idbut');
            var panel = $('.infoPanelData');

            if (maxtime == 0) {
                alert('Выходной'); return 0;
            }

            if (panel.is(':visible')) {
                panel.hide();
                return 0;
            }

            if (event.ctrlKey == true) {
                panel.css('top', target.offset().top + 40 - document.body.scrollTop);
                panel.css('left', target.offset().left - document.body.scrollLeft);

                $('input[name=idButVal]').val(idBut);
                $('input[name=kl]').val(valBut);
                panel.show();
            }
            else
                if (valBut != maxtime) target.text(+maxtime);
                else target.text('');
            RefreshData(rowBut);
        }
    });

$('.buttonDay').bind('mousemove', function (event) {
    if (event.shiftKey == true && event.which == 1) {
        var target = $(event.target);
        var maxtime = target.data('maxtime');
        var rowBut = target.data('row');
        if (maxtime == 0) {
            alert('Выходной'); return 0;
        }
        target.text(+maxtime);
        RefreshData(rowBut);
    }


}
);

$('#SubmitButton').click(function (event) {
    event.preventDefault();
    var val = +$('input[name=kl]').val();

    var Button = $('[data-idbut=' + $('input[name=idButVal]').val() + ']');

    var max = +Button.data('maxtime');
    var min = 0;
    if (val <= max & val >= min) {
        Button.text(val);
        $('.infoPanelData').hide();
        $('.infoPanelData').css('left', 0);
        $('.infoPanelData').css('top', 0);
        RefreshData(Button.data('row'));
    }
    else {
        alert("Значение должно быть больше: " + min + " и меньше: " + max);
    }
})

$('#CancelButton').click(function (event) {
    event.preventDefault();
    $('.infoPanelData').hide();
    $('.infoPanelData').css('left', 0);
    $('.infoPanelData').css('top', 0);
})

$(window).bind('scroll',function (event) {
    var panel = $('.infoPanelData');
    var vis = panel.is(":visible");
    if (vis === true) {
        panel.hide();
        $('.infoPanelData').css('left', 0);
        $('.infoPanelData').css('top', 0);
    }
});


