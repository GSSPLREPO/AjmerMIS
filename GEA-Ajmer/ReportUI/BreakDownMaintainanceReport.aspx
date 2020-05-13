<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="BreakDownMaintainanceReport.aspx.cs" Inherits="GEA_Ajmer.ReportUI.BreakDownMaintainanceReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Breakdown Maintenance </li>
        </ul>
    </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        Breakdown Maintenance
                    </div>
                    <div class="col-md-2 right" id="divExport" runat="server">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="imgbtnPDF_OnClick" CssClass="btn btn-danger quick-btn"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="imgbtnExcel_OnClick" CssClass="btn btn-success quick-btn"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="imgbtnWord_OnClick" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3">
                            From Date :
                        </div>
                        <div class="col-md-3">
                            To Date :
                        </div>
                        <div class="col-md-2">
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3 has-error">
                            <div class='input-group date' id='datetimepicker1'>
                                <asp:TextBox ID="txtFromDate" CssClass="fromdate form-control" Placeholder="From Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                        </div>
                        <div class="col-md-3 has-error">
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
                        <div class="col-md-4">
                        </div>
                    </div>
                </div>
                <br />
                <div class="row" style="overflow: scroll;">
                    <asp:GridView ID="gvBreakdown" runat="server" CssClass="table table-striped" GridLines="Both" AutoGenerateColumns="false" HeaderStyle-Wrap="false"> 
                        <Columns>
                                <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-Wrap="false"/>
                                <asp:BoundField DataField="StartTime" HeaderText="Start Time" ItemStyle-Wrap="false"/>
                                <asp:BoundField DataField="EndTime" HeaderText="End Time" ItemStyle-Wrap="false"/>
                                <asp:BoundField DataField="EquipmentTagNo" HeaderText="Equipment Tag No." ItemStyle-Wrap="false"/>
                                <asp:BoundField DataField="EquipmentName" HeaderText="Equipment Name" ItemStyle-Wrap="false"/>
                                <asp:BoundField DataField="PartNo" HeaderText="Part No." ItemStyle-Wrap="false"/>
                                <asp:BoundField DataField="PartName" HeaderText="Part Name" ItemStyle-Wrap="false"/>
                                <asp:BoundField DataField="Area" HeaderText="Area" ItemStyle-Wrap="false"/>
                                <asp:BoundField DataField="Dept" HeaderText="Dept." ItemStyle-Wrap="false"/>
                                <asp:BoundField DataField="Section" HeaderText="Section" ItemStyle-Wrap="false"/>
                                <asp:BoundField DataField="Cause" HeaderText="Cause" ItemStyle-Wrap="false"/>
                                <asp:BoundField DataField="DetailsofBreakdown" HeaderText="Breakdown Details" ItemStyle-Wrap="false"/>
                                <asp:BoundField DataField="ActionTaken" HeaderText="Action Taken" ItemStyle-Wrap="false"/>
                                <asp:BoundField DataField="RectifiedBy" HeaderText="Rectified By" ItemStyle-Wrap="false"/>
                                <asp:BoundField DataField="Remark" HeaderText="Remark" ItemStyle-Wrap="false"/>
                                <asp:BoundField DataField="UserId" HeaderText="User Id" ItemStyle-Wrap="false"/>
                            </Columns>
                    </asp:GridView>
                </div>
                <div class="col-md-12 center" id="divNo" runat="server">No records found.</div>
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
        //Timepicker
        $(".timepicker").timepicker({
            showInputs: false,
            use24hours: true,
            format: 'HH:mm',
            showMeridian: false,
            showSeconds: true,
            minuteStep: 1,
            secondStep: 10
        });
        $(".timepicker1").timepicker({
            showInputs: false,
            use24hours: true,
            format: 'HH:mm',
            showMeridian: false,
            showSeconds: true,
            minuteStep: 1,
            secondStep: 10

        });
    </script>
</asp:Content>
