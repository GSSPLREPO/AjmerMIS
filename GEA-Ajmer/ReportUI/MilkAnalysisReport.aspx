<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="MilkAnalysisReport.aspx.cs" Inherits="GEA_Ajmer.ReportUI.MilkAnalysisReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Milk Analysis Report</li>
        </ul>
    </div>

    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        Milk Analysis Report
                    </div>
                    <div class="col-md-2 right" id="divExport" runat="server">
                        <asp:LinkButton ID="imgbtnPDF" runat="server" OnClick="imgbtnPDF_OnClick" CssClass="btn btn-danger quick-btn"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="imgbtnExcel" runat="server" OnClick="imgbtnExcel_OnClick" CssClass="btn btn-success quick-btn"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
<%--                        <asp:LinkButton ID="imgbtnWord" runat="server" OnClick="imgbtnWord_OnClick" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>--%>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-4">
                            From Date :
                        </div>
                        <div class="col-md-4">
                            To Date :
                        </div>
                        <div class="col-md-2"></div>
                        <div class="col-md-2"></div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-4 has-error">
                            <div class='input-group date' id='datetimepicker1'>
                                <asp:TextBox ID="txtFromDate" CssClass="fromdate form-control" Placeholder="From Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                        </div>
                        <div class="col-md-4 has-error">
                            <div class='input-group date' id='datetimepicker2'>
                                <asp:TextBox ID="txtToDate" CssClass="form-control" Placeholder="To Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <asp:Button runat="server" ID="btnGo" Text="Go" CssClass="btn btn-primary pull-right" ValidationGroup="g1" OnClick="btnGo_OnClick" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFromDate" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter From Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtToDate" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter To Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2"></div>
                    </div>
                </div>
                <br />
                <div class="row" style="overflow: scroll;">
                    <asp:GridView runat="server" ID="gvMilkAnalysis" CssClass="table table-hover table-striped" 
                        AutoGenerateColumns="False" GridLines="Both" HeaderStyle-Wrap="false">
                        <Columns>
                            <asp:BoundField DataField="SrNo" HeaderText="Sr No." ItemStyle-Wrap="false"/>
                            <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-Wrap="false"/>
                            <asp:BoundField DataField="Time" HeaderText="Time" ItemStyle-Wrap="false"/>
                            <asp:BoundField DataField="SiloName" HeaderText="Silo Tag" ItemStyle-Wrap="false"/>
                            <asp:BoundField DataField="ProductType" HeaderText="Product Type" ItemStyle-Wrap="false"/>
                            <asp:BoundField DataField="SampleId" HeaderText="Sample ID" ItemStyle-Wrap="false"/>
                            <asp:BoundField DataField="FAT" HeaderText="FAT %" ItemStyle-Wrap="false"/>
                            <asp:BoundField DataField="SNF" HeaderText="SNF %" ItemStyle-Wrap="false"/>
                            <asp:BoundField DataField="Sugar" HeaderText="Sugar %" ItemStyle-Wrap="false"/>
                            <asp:BoundField DataField="TS" HeaderText="TS %" ItemStyle-Wrap="false"/>
                            <asp:BoundField DataField="Acidity" HeaderText="Acidity" ItemStyle-Wrap="false"/>
                            <asp:BoundField DataField="Temp" HeaderText="Temp" ItemStyle-Wrap="false"/>
                            <asp:BoundField DataField="OT" HeaderText="OT" ItemStyle-Wrap="false"/>
                            <asp:BoundField DataField="Name" HeaderText="User Id" ItemStyle-Wrap="false"/>
                            <asp:BoundField DataField="Remark" HeaderText="Remark" ItemStyle-Wrap="false"/>
                        </Columns>
                    </asp:GridView>
                </div>
                <%--<div class="col-md-12 center" id="divNo" runat="server">No records found.</div>--%>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        $('#datetimepicker1 input').datepicker({
            clearBtn: true,
            format: 'dd/mm/yyyy',
            autoclose: true,
            orientation: "top auto"
        });
        $('#datetimepicker2 input').datepicker({
            clearBtn: true,
            format: 'dd/mm/yyyy',
            autoclose: true,
            orientation: "top auto"
        });
    </script>
</asp:Content>
