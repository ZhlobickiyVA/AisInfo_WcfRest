<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainForm.Master" AutoEventWireup="true" CodeBehind="EditService.aspx.cs" Inherits="AisInfoService.Pages.Admin.EditService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../assets/vendor/ckeditor/ckeditor.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainForm" runat="server">
    <div class="panel panel-headline">
        <div class="panel-heading">
            <h2 class="panel-title">Карточка Услуги</h2>
        </div>
        <div class="panel-body">
            <div class="container-fluid">
                <div class="row">
                    <form>
                        <div class="col-md-12 form-group">
                            <label for="NameServ">Название услуги</label>
                            <input type="text" class="form-control" id="NameServ" placeholder="">
                        </div>
                        <div class="col-md-6 form-group">
                            <label for="slNameServ">Короткое название</label>
                            <input type="text" class="form-control" id="slNameServ" placeholder="">
                        </div>
                        <div class="col-md-6 form-group">
                            <label for="idFRGU">Идентификатор из ФРГУ</label>
                            <input type="text" class="form-control" id="idFRGU" placeholder="">
                        </div>
                        <div class="col-md-6 form-group">
                            <label for="idOGV">Орган власти</label>
                            <select name="idOGV" class="form-control">
                                <option>1</option>
                                <option>1</option>
                                <option>1</option>
                            </select>

                        </div>
                        <div class="col-md-6 form-group">
                            <label for="idCategory">Категория услуги</label>
                            <select name="idCategory" class="form-control">
                                <option>1</option>
                                <option>1</option>
                                <option>1</option>
                            </select>

                        </div>

                        <div class="col-md-6 form-group">
                            <label for="AccessFL">
                                <input type="checkbox" id="AccessFL" value="">
                                Услуга доступна Физическим лицам
                            </label>
                        </div>
                        <div class="col-md-6 form-group">
                            <label for="AccessUL">
                                <input type="checkbox" id="AccessUL" value="">
                                Услуга доступна Юридическим лицам
                            </label>
                        </div>
                        <div class="col-md-6 form-group">
                            <label for="AccessIP">
                                <input type="checkbox" id="AccessIP" value="">
                                Услуга доступна ИП лицам
                            </label>
                        </div>

                        <div class="col-md-6 form-group">
                            <label for="AccessNoNat">
                                <input type="checkbox" id="AccessNoNat" value="">
                                Услуга доступна лицам без гражданства
                            </label>
                        </div>

                        <div class="col-md-12 form-group">
                            <label for="AccessAIS">
                                <input type="checkbox" id="AccessAIS" value="">
                                Услуга открыта в АИС
                            </label>
                        </div>
                        <div class="col-md-4 form-group">
                            <label for="NameServ">Дата открытия доступа</label>
                            <input type="date" class="form-control" id="AccessData">
                        </div>



                        <div class="col-md-12 form-group">
                            <label for="NameServ">Инфомация по услуге</label>
                            <textarea name="editor1" id="editor1" rows="10" cols="80">
                        This is my textarea to be replaced with CKEditor.
                        </textarea>
                            <script>
                                // Replace the <textarea id="editor1"> with a CKEditor
                                // instance, using default configuration.
                                CKEDITOR.replace('editor1');
                            </script>
                        </div>

                        <div class="col-md-12 form-action mb20">
                            <button type="submit" class="btn btn-primary">Найти</button>
                            <button type="reset" class="btn btn-default">Очистить</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="server">
</asp:Content>
