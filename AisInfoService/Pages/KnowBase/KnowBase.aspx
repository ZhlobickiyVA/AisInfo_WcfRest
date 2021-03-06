﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainForm.Master" AutoEventWireup="true" CodeBehind="KnowBase.aspx.cs" Inherits="AisInfoService.Pages.KhowBase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="mainForm" runat="server">
    <div class="panel">
        <div class="panel-heading">
            <h1>База знаний - Список органов власти</h1>
        </div>
        <div class="panel-body">
            <form class="">
                <div class="input-group">
                    <input type="text" value="" class="form-control" placeholder="Введите название органа власти">
                    <span class="input-group-btn">
                        <button type="button" class="btn btn-primary">Найти</button></span>
                </div>
            </form>
        </div>
    </div>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">


    <div class="panel-group" id="ListDepartament">
        <div class="panel panel-info">
            <div class="panel-heading ">
                <h2 class="panel-title">Федеральные органы власти</h2>
                <div class="right"><button type="button" class="btn-toggle-collapse"><i class="lnr lnr-chevron-up"></i></button>               </div>
            </div>
            <div id="coll" class="panel-collapse in">
                <div class="panel-body">
                    <div class="panel-group listDep" id="accordion">
                        <div class="panel">
                            <div class="panel-heading ">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">
                                        <strong class="typeDep">РО&nbsp;</strong><span>Министерство дорожного хозяйства, транспорта и связи Магаданской области</span></a>
                                </h4>
                            </div>
                            <div id="collapse1" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <div class="infodepart container-fluid">
                                        <div class="col-md-9 mb20 val">
                                            <div><strong>Сокрашенное название:&nbsp;</strong><span>МИНДОРХОЗ МО</span> </div>
                                            <div><strong>Тип ведомства:&nbsp;</strong><span> Региональный</span></div>
                                            <div><strong>Регион:&nbsp;</strong><span>Магаданская область</span> </div>
                                            <div><strong>ИНН:&nbsp;</strong><span>5564546656545645646</span></div>
                                            <div><strong>Адресс:&nbsp;</strong><span> г.Магадан ул.Космонавнов 8</span></div>
                                            <div><strong>Ф.И.О. Руководителя:&nbsp;</strong><span> Мироненко А.А.</span></div>
                                            <div><strong>Телефон:&nbsp;</strong><span> 202525</span></div>
                                            <div>
                                                <strong>Примечание:&nbsp;</strong><br />
                                                <span>Текст примечания</span>
                                            </div>
                                        </div>
                                        <div class="col-md-3 mb20">
                                            <div class="mb20">

                                                <p class="text-center">
                                                    <img src="ServKnowBase.svc/json/GetImage?id=2" class="image img-thumbnail " onclick="document.location.href = this.src;" />
                                                </p>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <p class="text-right"><a class="btn btn-primary" href="#" role="button">Перейти к списку услуг &raquo;</a></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="panel">
                            <div class="panel-heading ">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">
                                        <strong class="typeDep">РО&nbsp;</strong><span>Министерство дорожного хозяйства, транспорта и связи Магаданской области</span></a>
                                </h4>
                            </div>
                            <div id="collapse2" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <div class="infodepart container-fluid">
                                        <div class="col-md-9 mb20 val">
                                            <div><strong>Сокрашенное название:&nbsp;</strong><span>МИНДОРХОЗ МО</span> </div>
                                            <div><strong>Тип ведомства:&nbsp;</strong><span> Региональный</span></div>
                                            <div><strong>Регион:&nbsp;</strong><span>Магаданская область</span> </div>
                                            <div><strong>ИНН:&nbsp;</strong><span>5564546656545645646</span></div>
                                            <div><strong>Адресс:&nbsp;</strong><span> г.Магадан ул.Космонавнов 8</span></div>
                                            <div><strong>Ф.И.О. Руководителя:&nbsp;</strong><span> Мироненко А.А.</span></div>
                                            <div><strong>Телефон:&nbsp;</strong><span> 202525</span></div>
                                            <div>
                                                <strong>Примечание:&nbsp;</strong><br />
                                                <span>Текст примечания</span>
                                            </div>
                                        </div>
                                        <div class="col-md-3 mb20">
                                            <div class="mb20">
                                                <p class="text-right">
                                                    <img src="ServKnowBase.svc/json/GetImage?id=2" class="image img-rounded " onclick="document.location.href = this.src;" />
                                                </p>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <p class="text-right"><a class="btn btn-primary" href="#" role="button">Перейти к списку услуг &raquo;</a></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="panel">
                            <div class="panel-heading ">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">
                                        <strong class="typeDep">РО&nbsp;</strong><span>Министерство дорожного хозяйства, транспорта и связи Магаданской области</span></a>
                                </h4>
                            </div>
                            <div id="collapse3" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <div class="infodepart container-fluid">
                                        <div class="col-md-9 mb20 val">
                                            <div><strong>Сокрашенное название:&nbsp;</strong><span>МИНДОРХОЗ МО</span> </div>
                                            <div><strong>Тип ведомства:&nbsp;</strong><span> Региональный</span></div>
                                            <div><strong>Регион:&nbsp;</strong><span>Магаданская область</span> </div>
                                            <div><strong>ИНН:&nbsp;</strong><span>5564546656545645646</span></div>
                                            <div><strong>Адресс:&nbsp;</strong><span> г.Магадан ул.Космонавнов 8</span></div>
                                            <div><strong>Ф.И.О. Руководителя:&nbsp;</strong><span> Мироненко А.А.</span></div>
                                            <div><strong>Телефон:&nbsp;</strong><span> 202525</span></div>
                                            <div>
                                                <strong>Примечание:&nbsp;</strong><br />
                                                <span>Текст примечания</span>
                                            </div>
                                        </div>
                                        <div class="col-md-3 mb20">
                                            <div class="mb20">
                                                <p class="text-right">
                                                    <img src="ServKnowBase.svc/json/GetImage?id=2" class="image img-rounded " onclick="document.location.href = this.src;" />
                                                </p>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <p class="text-right"><a class="btn btn-primary" href="#" role="button">Перейти к списку услуг &raquo;</a></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

        <div class="panel-group" id="ListDepartament2">
        <div class="panel panel-info">
            <div class="panel-heading ">
                <h2 class="panel-title">Муниципальные органы власти</h2>
                <div class="right"><button type="button" class="btn-toggle-collapse"><i class="lnr lnr-chevron-up"></i></button>               </div>
            </div>
            <div id="coll1" class="panel-collapse in">
                <div class="panel-body">
                    <div class="panel-group listDep" id="accordion1">
                        <div class="panel">
                            <div class="panel-heading ">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse101">
                                        <strong class="typeDep">РО&nbsp;</strong><span>Министерство дорожного хозяйства, транспорта и связи Магаданской области</span></a>
                                </h4>
                            </div>
                            <div id="collapse101" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <div class="infodepart container-fluid">
                                        <div class="col-md-9 mb20 val">
                                            <div><strong>Сокрашенное название:&nbsp;</strong><span>МИНДОРХОЗ МО</span> </div>
                                            <div><strong>Тип ведомства:&nbsp;</strong><span> Региональный</span></div>
                                            <div><strong>Регион:&nbsp;</strong><span>Магаданская область</span> </div>
                                            <div><strong>ИНН:&nbsp;</strong><span>5564546656545645646</span></div>
                                            <div><strong>Адресс:&nbsp;</strong><span> г.Магадан ул.Космонавнов 8</span></div>
                                            <div><strong>Ф.И.О. Руководителя:&nbsp;</strong><span> Мироненко А.А.</span></div>
                                            <div><strong>Телефон:&nbsp;</strong><span> 202525</span></div>
                                            <div>
                                                <strong>Примечание:&nbsp;</strong><br />
                                                <span>Текст примечания</span>
                                            </div>
                                        </div>
                                        <div class="col-md-3 mb20">
                                            <div class="mb20">

                                                <p class="text-center">
                                                    <img src="ServKnowBase.svc/json/GetImage?id=2" class="image img-thumbnail " onclick="document.location.href = this.src;" />
                                                </p>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <p class="text-right"><a class="btn btn-primary" href="#" role="button">Перейти к списку услуг &raquo;</a></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="panel">
                            <div class="panel-heading ">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse22">
                                        <strong class="typeDep">РО&nbsp;</strong><span>Министерство дорожного хозяйства, транспорта и связи Магаданской области</span></a>
                                </h4>
                            </div>
                            <div id="collapse22" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <div class="infodepart container-fluid">
                                        <div class="col-md-9 mb20 val">
                                            <div><strong>Сокрашенное название:&nbsp;</strong><span>МИНДОРХОЗ МО</span> </div>
                                            <div><strong>Тип ведомства:&nbsp;</strong><span> Региональный</span></div>
                                            <div><strong>Регион:&nbsp;</strong><span>Магаданская область</span> </div>
                                            <div><strong>ИНН:&nbsp;</strong><span>5564546656545645646</span></div>
                                            <div><strong>Адресс:&nbsp;</strong><span> г.Магадан ул.Космонавнов 8</span></div>
                                            <div><strong>Ф.И.О. Руководителя:&nbsp;</strong><span> Мироненко А.А.</span></div>
                                            <div><strong>Телефон:&nbsp;</strong><span> 202525</span></div>
                                            <div>
                                                <strong>Примечание:&nbsp;</strong><br />
                                                <span>Текст примечания</span>
                                            </div>
                                        </div>
                                        <div class="col-md-3 mb20">
                                            <div class="mb20">
                                                <p class="text-right">
                                                    <img src="ServKnowBase.svc/json/GetImage?id=2" class="image img-rounded " onclick="document.location.href = this.src;" />
                                                </p>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <p class="text-right"><a class="btn btn-primary" href="#" role="button">Перейти к списку услуг &raquo;</a></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="panel">
                            <div class="panel-heading ">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse32">
                                        <strong class="typeDep">РО&nbsp;</strong><span>Министерство дорожного хозяйства, транспорта и связи Магаданской области</span></a>
                                </h4>
                            </div>
                            <div id="collapse32" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <div class="infodepart container-fluid">
                                        <div class="col-md-9 mb20 val">
                                            <div><strong>Сокрашенное название:&nbsp;</strong><span>МИНДОРХОЗ МО</span> </div>
                                            <div><strong>Тип ведомства:&nbsp;</strong><span> Региональный</span></div>
                                            <div><strong>Регион:&nbsp;</strong><span>Магаданская область</span> </div>
                                            <div><strong>ИНН:&nbsp;</strong><span>5564546656545645646</span></div>
                                            <div><strong>Адресс:&nbsp;</strong><span> г.Магадан ул.Космонавнов 8</span></div>
                                            <div><strong>Ф.И.О. Руководителя:&nbsp;</strong><span> Мироненко А.А.</span></div>
                                            <div><strong>Телефон:&nbsp;</strong><span> 202525</span></div>
                                            <div>
                                                <strong>Примечание:&nbsp;</strong><br />
                                                <span>Текст примечания</span>
                                            </div>
                                        </div>
                                        <div class="col-md-3 mb20">
                                            <div class="mb20">
                                                <p class="text-right">
                                                    <img src="ServKnowBase.svc/json/GetImage?id=2" class="image img-rounded " onclick="document.location.href = this.src;" />
                                                </p>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <p class="text-right"><a class="btn btn-primary" href="#" role="button">Перейти к списку услуг &raquo;</a></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

        <div class="panel-group" id="ListDepartament3">
        <div class="panel panel-info">
            <div class="panel-heading ">
                <h2 class="panel-title">Региональные органы власти</h2>
                <div class="right"><button type="button" class="btn-toggle-collapse"><i class="lnr lnr-chevron-up"></i></button>               </div>
            </div>
            <div id="coll3" class="panel-collapse in">
                <div class="panel-body">
                    <div class="panel-group listDep" id="accordion3">
                        <div class="panel">
                            <div class="panel-heading ">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse10">
                                        <strong class="typeDep">РО&nbsp;</strong><span>Министерство дорожного хозяйства, транспорта и связи Магаданской области</span></a>
                                </h4>
                            </div>
                            <div id="collapse10" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <div class="infodepart container-fluid">
                                        <div class="col-md-9 mb20 val">
                                            <div><strong>Сокрашенное название:&nbsp;</strong><span>МИНДОРХОЗ МО</span> </div>
                                            <div><strong>Тип ведомства:&nbsp;</strong><span> Региональный</span></div>
                                            <div><strong>Регион:&nbsp;</strong><span>Магаданская область</span> </div>
                                            <div><strong>ИНН:&nbsp;</strong><span>5564546656545645646</span></div>
                                            <div><strong>Адресс:&nbsp;</strong><span> г.Магадан ул.Космонавнов 8</span></div>
                                            <div><strong>Ф.И.О. Руководителя:&nbsp;</strong><span> Мироненко А.А.</span></div>
                                            <div><strong>Телефон:&nbsp;</strong><span> 202525</span></div>
                                            <div>
                                                <strong>Примечание:&nbsp;</strong><br />
                                                <span>Текст примечания</span>
                                            </div>
                                        </div>
                                        <div class="col-md-3 mb20">
                                            <div class="mb20">

                                                <p class="text-center">
                                                    <img src="ServKnowBase.svc/json/GetImage?id=2" class="image img-thumbnail " onclick="document.location.href = this.src;" />
                                                </p>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <p class="text-right"><a class="btn btn-primary" href="#" role="button">Перейти к списку услуг &raquo;</a></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="panel">
                            <div class="panel-heading ">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse20">
                                        <strong class="typeDep">РО&nbsp;</strong><span>Министерство дорожного хозяйства, транспорта и связи Магаданской области</span></a>
                                </h4>
                            </div>
                            <div id="collapse20" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <div class="infodepart container-fluid">
                                        <div class="col-md-9 mb20 val">
                                            <div><strong>Сокрашенное название:&nbsp;</strong><span>МИНДОРХОЗ МО</span> </div>
                                            <div><strong>Тип ведомства:&nbsp;</strong><span> Региональный</span></div>
                                            <div><strong>Регион:&nbsp;</strong><span>Магаданская область</span> </div>
                                            <div><strong>ИНН:&nbsp;</strong><span>5564546656545645646</span></div>
                                            <div><strong>Адресс:&nbsp;</strong><span> г.Магадан ул.Космонавнов 8</span></div>
                                            <div><strong>Ф.И.О. Руководителя:&nbsp;</strong><span> Мироненко А.А.</span></div>
                                            <div><strong>Телефон:&nbsp;</strong><span> 202525</span></div>
                                            <div>
                                                <strong>Примечание:&nbsp;</strong><br />
                                                <span>Текст примечания</span>
                                            </div>
                                        </div>
                                        <div class="col-md-3 mb20">
                                            <div class="mb20">
                                                <p class="text-right">
                                                    <img src="ServKnowBase.svc/json/GetImage?id=2" class="image img-rounded " onclick="document.location.href = this.src;" />
                                                </p>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <p class="text-right"><a class="btn btn-primary" href="#" role="button">Перейти к списку услуг &raquo;</a></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="panel">
                            <div class="panel-heading ">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse30">
                                        <strong class="typeDep">РО&nbsp;</strong><span>Министерство дорожного хозяйства, транспорта и связи Магаданской области</span></a>
                                </h4>
                            </div>
                            <div id="collapse30" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <div class="infodepart container-fluid">
                                        <div class="col-md-9 mb20 val">
                                            <div><strong>Сокрашенное название:&nbsp;</strong><span>МИНДОРХОЗ МО</span> </div>
                                            <div><strong>Тип ведомства:&nbsp;</strong><span> Региональный</span></div>
                                            <div><strong>Регион:&nbsp;</strong><span>Магаданская область</span> </div>
                                            <div><strong>ИНН:&nbsp;</strong><span>5564546656545645646</span></div>
                                            <div><strong>Адресс:&nbsp;</strong><span> г.Магадан ул.Космонавнов 8</span></div>
                                            <div><strong>Ф.И.О. Руководителя:&nbsp;</strong><span> Мироненко А.А.</span></div>
                                            <div><strong>Телефон:&nbsp;</strong><span> 202525</span></div>
                                            <div>
                                                <strong>Примечание:&nbsp;</strong><br />
                                                <span>Текст примечания</span>
                                            </div>
                                        </div>
                                        <div class="col-md-3 mb20">
                                            <div class="mb20">
                                                <p class="text-right">
                                                    <img src="ServKnowBase.svc/json/GetImage?id=2" class="image img-rounded " onclick="document.location.href = this.src;" />
                                                </p>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <p class="text-right"><a class="btn btn-primary" href="#" role="button">Перейти к списку услуг &raquo;</a></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>






</asp:Content>
