<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainForm.Master" AutoEventWireup="true" CodeBehind="ListForm.aspx.cs" Inherits="AisInfoService.Pages.ListForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="panel panel-headline">
        <div class="panel-heading">
            <h3 class="panel-title">Weekly Overview</h3>
            <p class="panel-subtitle">Period: Oct 14, 2016 - Oct 21, 2016</p>
        </div>
        <div class="panel-body">
            <div class="row">
                <table class="table table-hover table-responsive table-striped">
                    <thead>
                        <tr>
                            <th>Фамилия</th>
                            <th>Имя</th>
                            <th>Отчество</th>
                            <th>Дата рождения</th>
                            <th>№ ДОУ</th>
                            <th>% выплаты</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>1</td>
                            <td>Steve</td>
                            <td>Jobs</td>
                            <td>@steve</td>
                            <td>Philips</td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>Simon</td>
                            <td>Philips</td>
                            <td>@simon</td><td>Philips</td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td>Jane</td>
                            <td>Doe</td>
                            <td>@jane</td><td>Philips</td>
                        </tr>
                    </tbody>
                </table>
            </div>

        </div>
    </div>
</asp:Content>
