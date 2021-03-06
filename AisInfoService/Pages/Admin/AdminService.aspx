﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainForm.Master" AutoEventWireup="true" CodeBehind="AdminService.aspx.cs" Inherits="AisInfoService.Pages.AdminService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ul>
        <li>
            <a href="ServList.svc">Сервис запроса информации от соц центра</a>
            <ul>
                <li><a href="ServList.svc/json/Connect">Test - Connect JSON</a></li>
                <li><a href="ServList.svc/xml/Connect">Test - Connect XML</a></li>
                <li><a href="ServList.svc/Connect">Test - Connect SOAP</a></li>
                <li><a href="ServList.svc/json/ListKinder">Test - Get_ListKinder JSON</a></li>
                <li><a href="ServList.svc/json/ListKinder?brdate=21.03.2012">TestParamBrDate - Get_ListKinder JSON</a></li>
                <li><a href="ServList.svc/json/ListKinder?brdate=&ndou=02">TestParamNumDou - Get_ListKinder JSON</a></li>
                <li><a href="ServList.svc/json/ListDOU">Test - GetListDOU JSON</a></li>
                <li><a href="ServList.svc/json/ListEDV">Test - GetListEDV JSON</a></li>
                <li><a href="ServList.svc/json/ListOldLive">Test - GetListOldLive JSON</a></li>
                <!--"ListPayKinder?lname={lname}&fname={fname}&mname={mname}&brdate={brdate}"-->
                <li><a href="ServList.svc/json/ListPayKinder">Test - GETListPayKinder JSON</a></li>
            </ul>
        </li>
        <li>
            <a href="ServPrice.svc">Сервис формирования платежной квитанции</a>
            <ul>
                <li><a href="ServPrice.svc/json/Connect">Test - Connect  JSON</a></li>
                <li><a href="ServPrice.svc/json/ListOGV">Test - ListOGV  JSON</a></li>
                <li><a href="ServPrice.svc/json/ListDul">Test - ListDUL  JSON</a></li>
                <li><a href="ServPrice.svc/json/PriceDocument">Test - PriceDocument</a></li>

            </ul>
        </li>
        <li>
            <a href="ServInfo.svc">Сервис дополнительной информации</a>
            <ul>
                <li><a href="ServInfo.svc/json/Connect">Test - Connect  JSON</a></li>
                <li><a href="ServInfo.svc/json/GetListArea">Test - GetListArea  JSON</a></li>
                <li><a href="ServInfo.svc/json/GetLisMdou">Test - GetListMDOU  JSON</a></li>


            </ul>
        </li>
        <li>
            <a href="ServKnowBase.svc">Сервис базы знаний</a>
            <ul>
                <li><a href="ServKnowBase.svc/json/Connect">Test - Connect  JSON</a></li>
                <li><a href="ServKnowBase.svc/json/posttest">Test - posttest  JSON</a></li>
                <li><a href="ServKnowBase.svc/json/image">Test - Image  JSON</a></li>
                <li><a href="ServKnowBase.svc/json/ListData">Test - ListData  JSON</a></li>
                <li><a href="ServKnowBase.svc/json/GetImage?id=2">Test - GetImage id=2  JSON</a></li>


            </ul>
        </li>
    </ul>
    
    <a href="Admin/EditService">Admin/EditService.aspx</a>
 
    <img src="ServKnowBase.svc/json/GetImage?id=2" width="200" height="200" onclick="document.location.href = this.src;" />
</asp:Content>

<%-- <!--<script>
        function BindListDou() {
            $.ajax(
                {
                    type: "GET",
                    url: 'ServPrice.svc/json/ListDul',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    cache: false,
                    success: function (data) {

                        for (var i = 0; i < data.length; i++) {

                            document.getElementById('ListDou').appendChild(new Option(data[i].name, data[i].id));
                        };
                    },
                    error: function (msg) {
                        alert(msg.responseText);
                    }
                })
        };

        function BindListOGV() {
            $.ajax(
                {
                    type: "GET",
                    url: 'ServPrice.svc/json/ListOGV',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    cache: false,
                    
                    success: function (data) {

                        for (var i = 0; i < data.length; i++) {

                            document.getElementById('ListOGV').appendChild(new Option(data[i].name, data[i].id));
                        };
                    },
                    error: function (msg) {
                        alert(msg.responseText);
                    }
                })
        };
        function BindListPurpose(index) {
            if (index == undefined || index == null) {
                index = document.forms["form1"]["ListOGV"].value;
            }

            $.ajax(
                {
                    type: "GET",
                    url: 'ServPrice.svc/json/ListPurpose?idOgv=' + index,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    cache: false,
                    success: function (data) {
                        $("#ListPurpose").empty();
                        for (var i = 0; i < data.length; i++) {

                            document.getElementById('ListPurpose').appendChild(new Option(data[i].name, data[i].id));
                        };
                    },
                    error: function (msg) {
                        alert(msg.responseText);
                    }
                })
        };

        BindListDou();
        BindListOGV();
        BindListPurpose(0);
    </script>-->

  <!--<script>
        function PostTest()
        {
            $.ajax(
                {
                    type: "POST",
                    url: 'ServKnowBase.svc/json/posttest',
                    data: {  da : {x:5,y:5}},
                    contentType: "application/http; charset=utf-8",
                    dataType: "json",
                    cache: false,
                    success: function (data) {
                        alert(data);
                    },
                    error: function (msg) {
                        alert(msg.responseText);
                    }
                })

        }

    </script>-->





    <!--<form name="form" method="post" action="ServKnowBase.svc/json/posttest" >
        <select name="Ogv">
            <option value="1">МВД</option>
            <option value="2">ЗАГС</option>
        </select>
        <input type="text" name="Lname" placeholder="Lname" /><br />
        <input type="text" name="Fname" placeholder="Fname" /><br />
        <input type="text" name="Mname" placeholder="Mname" /><br />
        <input type="text" name="Adress" placeholder="Adress" /><br />
        <select name="VidDul">
            <option value="1">Паспорт</option>
            <option value="2">СНИЛС</option>
        </select>
        <input type="text" name="NumberDul" placeholder="NumberDul" /><br />
        <input type="text" name="Nationaly" placeholder="Nationaly" /><br />
        <select name="Purpose">
            <option value="1">Паспорт</option>
            <option value="2">Загранпаспорт</option>
        </select>
        
        <input type="file" name="file" />

        <input type="submit" value="Старт" "/>
    </form>-->
    
    <!--<script>
        function GetData() {
            $.ajax(
                {
                    type: "GET",
                    url: 'ServKnowBase.svc/json/ListData',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    cache: false,
                    success: function (data) {
                        for (var i = 0; i < data.length; i++) {
                            $('#listdata').append('<div style="margin:2px 5px; border:1px solid green; padding:2px;">' + data[i].Name);
                            for (var j = 0; j < data[i].Services.length; j++) {
                                $('#listdata').append('<div style="margin:10px 10px; border:1px solid red; padding:2px;">' + data[i].Services[j].Name + '</div>');
                            }


                            $('#listdata').append('</div>');
                        };
                    },
                    error: function (msg) {
                        alert(msg.responseText);
                    }
                })
        };
        GetData();
    </script>

    <div id="listdata"></div>-->

    <!--<form action="ServPrice.svc/json/PriceDocument" id="form1" method="get">
        <select name="idOgv" id="ListOGV" style="width:100px;" onchange="BindListPurpose()"></select><br />
        <select name="idPur" id="ListPurpose" style="width:100px;"></select><br />
        <input type="text" id="lname" name="lname" placeholder="Фамилия" /><br><br>
        <input type="text" id="fname" name="fname" placeholder="Имя" /><br><br>
        <input type="text" id="mname" name="mname" placeholder="Отчество" /><br><br>
        <input type="text" id="adress" name="adress" placeholder="Адресс" /><br><br>
        <select name="idtype" id="ListDou" style="width:100px;"></select><br /><br />
        <input type="text" id="NumDoc" name="numdul" placeholder="Номер документа" /><br/><br/>

        <input type="submit" value="Войти" />-->
        <!-- string adress="", string idtype="", string numdul=""-->
    <!--</form>-->
    <!--<div id="result" style="background-color:white;margin-top:20px;">
        <div style="margin:2px 5px; border:1px solid green;">
            Список горжилсервис
            <div/>
        
        <script>
            $.ajax(
        {
            type: "GET",
            url: 'ServInfo.svc/json/GetListArea',
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (data) {
                $("#result").empty();
                for (var i = 0; i < data.length; i++) {
                    $("#result").append(
                        '<div  style="padding:10px; border:1px solid red; margin-top:2px;">' +
                        data[i].id + ' ' + data[i].Name + ' ' + data[i].Adress + ' ' + data[i].Phone);

                    for (var j = 0; j < data[i].Street.length; j++) {
                        $("#result").append('<div style="margin:2px 5px; border:1px solid green; padding:2px;">' + data[i].Street[j].Name + ' ' + data[i].Street[j].House.join() + ' </div>'

                            );


                    }
                        $("#result").append('<div/>');
                    
                        
                }
                
             

            },
            error: function (msg) {
                alert(msg.responseText);
            }
        })

        </script>
    </div>-->
--%>