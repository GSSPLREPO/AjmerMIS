<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="AboutSoftware.aspx.cs" Inherits="GEA_Ajmer.AboutSoftware" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">About Software</li>
        </ul>
    </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        About Software
                    </div>
                </div>
            </div>
            <div class="panel-body">
                Client : GEA
                        <br />
                Software Release Date : 28/12/2015
                        <br />
                Software Version : v1.0
                        <br />
                Developed By : BTSS (Banyan Tree Software Solution)
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
