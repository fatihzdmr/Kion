<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="kion.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>

    <link href="css/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        body {
            padding-top: 60px;
            padding-bottom: 40px;
        }


        .bgcolor {
            background-color: none;
        }

        .lightblue {
            background-color: none;
        }

        .form-horizontal .control-label {
            width: 82px;
        }
        
        .form-horizontal .controls {
            margin-left: 90px;
        }

        .form-horizontal .control-label2 {
            width: 130px;
        }
        .form-horizontal .controls2 {
            margin-left: 140px;
        }
    </style>
    <link href="css/bootstrap-responsive.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="navbar-inner">
                <div class="container-fluid">
                    <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </a>
                    <a class="brand" href="#">KION Ön Kayıt Formu</a>

                </div>
            </div>
        </div>


        <div class="container-fluid">
            <div class="form-horizontal">
                <legend>Aday Ön Kayıt Formu</legend>
                <div class="row-fluid">
                    <div class="span8">
                        <%--<div class="row-fluid">
            <div class="span12 bgcolor">
              <div class="alert alert-error">
              <a href="#" class="close" data-dismiss="alert">×</a>
                Hata mesajları.
              </div>
            </div>
          </div>--%>
                        <div class="row-fluid">
                            <div class="span12 bgcolor">
                                <div class="control-group">
                                    <label class="control-label">Aday TCKN</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtTckn" runat="server" class="input-xxlarge" placeHolder="Kimlik Numaranızı Giriniz" TextMode="Number" MaxLength="11" OnTextChanged="txtTckn_TextChanged" AutoPostBack="true"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6 bgcolor">
                                <div class="control-group">
                                    <label class="control-label" for="adi">Adı</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtAd" runat="server" placeHolder="Adınızı Giriniz"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <!--/span-->
                            <div class="span6 bgcolor">
                                <div class="control-group">
                                    <label class="control-label" for="soyadi">Soyadı</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtSoyad" runat="server" placeHolder="Soyadınızı Giriniz"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <!--/span-->
                        </div>
                        <!--/row-->
                        <div class="row-fluid">
                            <div class="span6 bgcolor">
                                <div class="control-group">
                                    <label class="control-label">GSM</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtGsm" runat="server" placeHolder="Cep Telefonu Numaranızı Giriniz"></asp:TextBox>


                                    </div>
                                </div>
                            </div>
                            <!--/span-->
                            <div class="span6 bgcolor">
                                <div class="control-group">
                                    <label class="control-label">E-Posta</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtEPosta" runat="server" placeHolder="E-Postanızı Giriniz"></asp:TextBox>


                                    </div>
                                </div>
                            </div>
                            <!--/span-->
                        </div>
                        <!--/row-->

                        <fieldset>
                            <legend>Aile Bilgileri</legend>

                            <div class="row-fluid">
                                <div class="span6 bgcolor">
                                    <div class="control-group">
                                        <label class="control-label">Anne Adı</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtAnneAd" runat="server" placeHolder="Anne Adını Giriniz"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <!--/span-->
                                <div class="span6 bgcolor">
                                    <div class="control-group">
                                        <label class="control-label">Anne Soyadı</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtAnneSoyad" runat="server" placeHolder="Anne Soyadını Giriniz"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <!--/span-->
                            </div>
                            <!--/row-->

                            <div class="row-fluid">
                                <div class="span6 bgcolor">
                                    <div class="control-group">
                                        <label class="control-label">Baba Adı</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtBabaAd" runat="server" placeHolder="Baba Adını Giriniz"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <!--/span-->
                                <div class="span6 bgcolor">
                                    <div class="control-group">
                                        <label class="control-label">Baba Soyadı</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtBabaSoyad" runat="server" placeHolder="Baba Soyadını Giriniz"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <!--/span-->
                            </div>
                            <!--/row-->

                            <!--/row-->
                        </fieldset>


                        <fieldset>
                            <legend>Üniversite Bilgileri</legend>
                            <div class="row-fluid">
                                <div class="span12 bgcolor">
                                    <div class="control-group">
                                        <label class="control-label">Üniversite</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlUniversite" runat="server" AppendDataBoundItems="True" DataSourceID="LinqDataSource1" DataTextField="uniAd" DataValueField="uniId" AutoPostBack="True" OnSelectedIndexChanged="ddlUniversite_SelectedIndexChanged">
                                                <asp:ListItem Value="-1">Üniversite Seçin</asp:ListItem>
                                            </asp:DropDownList>

                                            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="kion.kionEntities1" EntityTypeName="" Select="new (uniId, uniAd)" TableName="universite">
                                            </asp:LinqDataSource>
                               

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--/span-->

                            <div class="row-fluid">
                                <div class="span6 bgcolor">
                                    <div class="control-group">
                                        <label class="control-label" for="postakodu">Fakülte</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlFakulte" runat="server" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="ddlFakulte_SelectedIndexChanged">
                                                <asp:ListItem Value="-1">Fakülte Seçin</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <!--/span-->
                                <div class="span6 bgcolor">
                                    <div class="control-group">
                                        <label class="control-label" for="ulke">Bölüm</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlBolum" runat="server" AppendDataBoundItems="true" AutoPostBack="True">
                                                <asp:ListItem Value="-1">Bölüm Seçin</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                </div>
                                <!--/span-->



                            </div>


                        </fieldset>


                        <fieldset>
                            <legend>Dökümanlar</legend>

                            <div class="row-fluid">
                                <div class="span12 bgcolor">
                                    <div class="control-group">
                                        <label class="control-label2">Ales Belgesi (PDF)</label>
                                        <div class="controls2">
                                            <asp:FileUpload ID="fuAles" runat="server" />

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span12 bgcolor">
                                    <div class="control-group">
                                        <label class="control-label2">Diploma (PDF)</label>
                                        <div class="controls2">
                                            <asp:FileUpload ID="fuDiploma" runat="server" />

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span12 bgcolor">
                                    <div class="control-group">
                                        <label class="control-label2">Askerlik Durum Belgesi (PDF)</label>
                                        <div class="controls2">
                                            <asp:FileUpload ID="fuAskerlik" runat="server" />
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>





                        </fieldset>






                        <div class="span6 bgcolor"></div>
                        <div class="span6 bgcolor">

                        
                            <asp:Button ID="btnKaydet" runat="server" class="btn btn-primary" Text="Kaydet" OnClick="btnKaydet_Click" />
                        </div>
                    </div>
                    <!--/span-->

                    <div class="span4">
                    </div>
                    <!--/span-->
                </div>
                <!--/row-->
            </div>

            <hr>
        </div>
        <!--/.fluid-container-->
    </form>
    <script src="js/jquery-1.8.0.min.js"></script>
    <script src="js/bootstrap.js"></script>
</body>
</html>
