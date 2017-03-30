function BindGridView(val) {
    if (val === 1) {
        var param = 'List';
        var Lname = document.forms["form1"]["Lname"].value;
        var Fname = document.forms["form1"]["Fname"].value;
        var Mname = document.forms["form1"]["Mname"].value;
        var Brdate = document.forms["form1"]["DrDate"].value;

        var idDou = document.forms["form1"]["ListDou"].value;
        var indexDou = document.forms["form1"]["ListDou"].selectedIndex;

        
        if (Lname === null || Lname === "")
        {
           Lname = "";
        }
        if (Fname === null || Fname === "") {
            Fname = "";
        }
        if (Mname === null || Mname === "") {
            Mname = "";
        }
        if (indexDou === 0) {
            idDou = "";
        }
        if (Brdate === null || Brdate === "") {
            Brdate = "";
        }

        param = 'List?LastName=' + Lname + '&FirstName='+Fname+'&MiddleName='+Mname;

    }
    else
    { param = 'List'; }

    
    $.ajax(
        {
            type: "GET",
            url: '/Service.svc/json/'+param,
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (data) {
                var datamas = data.JSONListResult;
                $(".table").empty();
                $(".table").append(
                    '<th>Фамилия</th>'
                    + '<th>Имя</th>'
                    + '<th>Отчество</th>'
                    + '<th>Дата рождения</th>'
                    + '<th>Номер ДОУ</th>'
                    + '<th>Размер выплаты</th>'
                    )
                for (var i = 0; i < datamas.length; i++) {
                    $(".table").append(

                    '<tr>'
                    + '<td>' + datamas[i].LastName + '</td>'
                    + '<td>' + datamas[i].FirstName + '</td>'
                    + '<td>' + datamas[i].MiddleName + '</td>'
                    + '<td>' + datamas[i].BrDate + '</td>'
                    + '<td>' + datamas[i].NumDou + '</td>'
                    + '<td>' + datamas[i].Razmer + '</td>'
                    + '</tr>');
                };

            },
            error: function (msg) {
                alert(msg.responseText);
            }
        })
};


function BindListDou() {
    $.ajax(
        {
            type: "GET",
            url: '/Service.svc/json/ListDou',
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (data) {
                var datamas = data.JSONListDouResult;

                for (var i = 0; i < datamas.length; i++) {
                    document.getElementById('ListDou').appendChild(new Option(datamas[i]));
                    
                };

            },
            error: function (msg) {
                alert(msg.responseText);
            }
        })
};

