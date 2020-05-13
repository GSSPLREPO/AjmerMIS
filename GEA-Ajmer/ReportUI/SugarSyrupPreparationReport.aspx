<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="SugarSyrupPreparationReport.aspx.cs" Inherits="GEA_Ajmer.ReportUI.SugarSyrupPreparationReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active"><i class="fa fa-file"></i>Sugar Syrup Preparation Report </li>
        </ul>
    </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        Sugar Syrup Preparation Report
                    </div>
                    <div class="col-md-2 right" id="divExport" runat="server">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="imgbtnPDF_OnClick" CssClass="btn btn-danger quick-btn"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="imgbtnExcel_OnClick" CssClass="btn btn-success quick-btn"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
<%--                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="imgbtnDoc_OnClick" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>--%>
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
                        <%-- <div class="col-md-2">
                            Vat No
                        </div>--%>
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
                        <%--<div class="col-md-2">
                            <asp:DropDownList ID="ddlVatNo" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>--%>
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
                <div id="divExport1" runat="server">
                    <div class="row" style="overflow: scroll;">
                        
                        <asp:GridView runat="server" ID="gvSugarSyrup" CssClass="table table-hover table-striped"
                            AutoGenerateColumns="False" GridLines="Both" HeaderStyle-Wrap="false">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtID" runat="server" Visible="false"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:BoundField DataField="Id" HeaderText="ID" Visible="false" />
                                <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Time" HeaderText="Time" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="VatNo" HeaderText="Vat No." ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="QtyWaterTaken" HeaderText="Qty of Water taken (Ltr)" />
                                <asp:TemplateField HeaderText="Qty of Sugar taken (Ltr)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtQtySugar" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="BatchStartTime" HeaderText="Batch Start Time"
                                    ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="BatchStopTime" HeaderText="Batch End Time" 
                                    ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="BatchTotalTime" HeaderText="Batch Total Time" 
                                    ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Tank" HeaderText="Transfer to SMT No." ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="SugarSilo" HeaderText="Qty. Of Sugar syrup trasferred" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="WaterQty" HeaderText="Transfer Start Time"
                                    ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="SugarQty" HeaderText="Transfer End Time" 
                                    ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="BatchTemp" HeaderText="Total transfer Time"
                                    ItemStyle-Wrap="false" />
                               <%-- <asp:BoundField DataField="TransferSiloNo" HeaderText="Transfer to Silo No." ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="SugarSyrupTransferQty" HeaderText="Qty. Of Sugar syrup trasferred (Ltr)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="TransferStartTime" HeaderText="Transfer Start Time" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="TransferStopTime" HeaderText="Transfer End Time" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="TransferTotalTime" HeaderText="Total Transfer Time" ItemStyle-Wrap="false" />--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="row"></div>
                    <div class="row">
                        <div class="col-md-10"></div>
                        <div class="col-md-2">
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" 
                                CssClass="btn btn-primary pull-right" />
                        </div>
                    </div>
                </div>
                <div class="col-md-12 center" id="divRecord" runat="server">No records found.</div>
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
