<%@ Page Title="" Language="C#" MasterPageFile="~/MainForm.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AisInfoService.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="../Scripts/ajax.js"></script>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="MainSidebar" runat="server">
    <ul class="nav nav-sidebar" id="SideBar">
                    <li class="active"><a id="a0" href="#">Информация по ДОУ <span class="sr-only">(current)</span></a></li>
                    <li><a id="a1" href="#">Информация по ЕДВ</a></li>
                    <li><a id="a2" href="#">Информация по Старожиламs</a></li>
                    <li><a id="a3" href="#">Информация по Ежемесячному пособую на ребенка</a></li>
                </ul>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="MainHeader" runat="server">
    <h2 class="sub-header">Информация по ДОУ</h2>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainForm" runat="server">
                    <form class="form-group formsearch" name="SearchForm">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="form-group col-md-4">
                                <input type="text" class="form-control" name="Lname" placeholder="Фамилия">
                            </div>
                            <div class="form-group col-md-4">
                                <input type="email" class="form-control" name="Fname" placeholder="Имя">
                            </div>
                            <div class="form-group col-md-4">
                                <input type="text" class="form-control" name="Mname" placeholder="Отчество">
                            </div>
                            <div class="form-group col-md-4">
                                <label for="exampleInputEmail">Дата рождения</label>
                                <input type="date" class="form-control" name="DateBr" placeholder="Дата рождения">
                            </div>
                            <div class="form-group col-md-4">
                                <label for="NumDou">№ ДОУ</label>
                                <select class="form-control" name="NumDou">
                                    <option>1</option>
                                    <option>2</option>
                                    <option>3</option>
                                    <option>4</option>
                                    <option>5</option>
                                </select>
                            </div>

                        </div>
                        <div class="form-actions">
                            <button type="button" class="btn btn-primary" id="BtnSearch">Поиск</button>
                            <button type="reset" class="btn">Очистить</button>
                        </div>
                    </div>
                    </form>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainInfo" runat="server">
<div class="table-responsive">
<table class="table table-striped table-hover" id="TableRow">
              <thead>
                <tr>
                  <th>#</th>
                  <th>Header</th>
                  <th>Header</th>
                  <th>Header</th>
                  <th>Header</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>1,001</td>
                  <td>Lorem</td>
                  <td>ipsum</td>
                  <td>dolor</td>
                  <td>sit</td>
                </tr>
                <tr>
                  <td>1,002</td>
                  <td>amet</td>
                  <td>consectetur</td>
                  <td>adipiscing</td>
                  <td>elit</td>
                </tr>
                <tr>
                  <td>1,003</td>
                  <td>Integer</td>
                  <td>nec</td>
                  <td>odio</td>
                  <td>Praesent</td>
                </tr>
                <tr>
                  <td>1,003</td>
                  <td>libero</td>
                  <td>Sed</td>
                  <td>cursus</td>
                  <td>ante</td>
                </tr>
                <tr>
                  <td>1,004</td>
                  <td>dapibus</td>
                  <td>diam</td>
                  <td>Sed</td>
                  <td>nisi</td>
                </tr>
                <tr>
                  <td>1,005</td>
                  <td>Nulla</td>
                  <td>quis</td>
                  <td>sem</td>
                  <td>at</td>
                </tr>
                <tr>
                  <td>1,006</td>
                  <td>nibh</td>
                  <td>elementum</td>
                  <td>imperdiet</td>
                  <td>Duis</td>
                </tr>
                <tr>
                  <td>1,007</td>
                  <td>sagittis</td>
                  <td>ipsum</td>
                  <td>Praesent</td>
                  <td>mauris</td>
                </tr>
                <tr>
                  <td>1,008</td>
                  <td>Fusce</td>
                  <td>nec</td>
                  <td>tellus</td>
                  <td>sed</td>
                </tr>
                <tr>
                  <td>1,009</td>
                  <td>augue</td>
                  <td>semper</td>
                  <td>porta</td>
                  <td>Mauris</td>
                </tr>
                <tr>
                  <td>1,010</td>
                  <td>massa</td>
                  <td>Vestibulum</td>
                  <td>lacinia</td>
                  <td>arcu</td>
                </tr>
                <tr>
                  <td>1,011</td>
                  <td>eget</td>
                  <td>nulla</td>
                  <td>Class</td>
                  <td>aptent</td>
                </tr>
                <tr>
                  <td>1,012</td>
                  <td>taciti</td>
                  <td>sociosqu</td>
                  <td>ad</td>
                  <td>litora</td>
                </tr>
                <tr>
                  <td>1,013</td>
                  <td>torquent</td>
                  <td>per</td>
                  <td>conubia</td>
                  <td>nostra</td>
                </tr>
                <tr>
                  <td>1,014</td>
                  <td>per</td>
                  <td>inceptos</td>
                  <td>himenaeos</td>
                  <td>Curabitur</td>
                </tr>
                <tr>
                  <td>1,015</td>
                  <td>sodales</td>
                  <td>ligula</td>
                  <td>in</td>
                  <td>libero</td>
                </tr>
              </tbody>
            </table>
</div>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="Script" runat="server">

</asp:Content>
