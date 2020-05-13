<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="TrendsRepors.aspx.cs" Inherits="GEA_Ajmer.ReportUI.TrendsRepors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">
                <asp:Label ID="lblHeader1" runat="server"></asp:Label></li>
        </ul>
    </div>


    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        <asp:Label ID="lblHeader2" runat="server"></asp:Label>
                    </div>
                    <div class="col-md-2 right" id="divExport" runat="server">
                        <asp:LinkButton ID="imgbtnPDF" runat="server" OnClick="imgbtnPDF_Click" CssClass="btn btn-danger quick-btn"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="imgbtnExcel" runat="server" OnClick="imgbtnExcel_Click" CssClass="btn btn-success quick-btn"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                        <%--<asp:LinkButton ID="imgbtnWord" runat="server" OnClick="imgbtnWord_Click" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>--%>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-3">
                        From Date :
                    </div>
                    <div class="col-md-3">
                        From Time :
                    </div>
                    <div class="col-md-3">
                        To Date :
                    </div>
                    <div class="col-md-3">
                        To Time :
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
                        <div class="col-md-3">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtFromTime" ClientIDMode="Static" CssClass="form-control timepicker" Placeholder="From Time" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-3 has-error">
                            <div class='input-group date' id='datetimepicker2'>
                                <asp:TextBox ID="txtToDate" CssClass="form-control" Placeholder="To Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtToTime" ClientIDMode="Static" CssClass="form-control timepicker1" Placeholder="To Time" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                    </div>
                                </div>
                            </div>
                        </div>

                      <%--  <div class="col-md-2 has-error">
                            <div class='input-group date' id='divPaste'>
                                <asp:DropDownList ID="ddlPasteuriser" runat="server" CssClass="form-control input-sm inline-block">
                                    <asp:ListItem Text="--SelectAll--" Value="-1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="MPL-1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="MPL-2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="CPL" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Curd Paste." Value="4"></asp:ListItem>
                                    <asp:ListItem Text="BM" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="MPLBM" Value="6"></asp:ListItem>
                                </asp:DropDownList>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-arrow-down"></span></span>
                            </div>
                        </div>--%>
                    </div>
                </div>
                <%-- ---------- --%>
                <div class="row">
                    <div class="col-md-3">
                       Pasteuriser :
                    </div>
                </div>
                 <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-2 has-error">
                            <div class='input-group date' id='divPaste'>
                                <asp:DropDownList ID="ddlPasteuriser" runat="server" CssClass="form-control input-sm inline-block">
                                    <asp:ListItem Text="--SelectAll--" Value="-1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="MPL-1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="MPL-2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="CPL" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Curd Paste." Value="4"></asp:ListItem>
                                    <asp:ListItem Text="BM" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="MPLBM" Value="6"></asp:ListItem>
                                </asp:DropDownList>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-arrow-down"></span></span>
                            </div>
                        </div>
                    </div>
                </div>

                <%-- ------ --%>
            </div>

            <div class="row" style="margin-top: 10px; padding-bottom: 15px;">
                <div class="col-md-12">
                    <div class="col-md-8">
                    </div>
                    <div class="col-md-4">
                        <asp:Button runat="server" ID="btnGo" Text="Go" CssClass="btn btn-primary pull-right" ValidationGroup="g1" OnClick="btnGo_Click" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFromDate" ValidationGroup="g1"
                            SetFocusOnError="True" ErrorMessage="Enter From Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtToDate" ValidationGroup="g1"
                            SetFocusOnError="True" ErrorMessage="Enter To Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

            <div class="row col-md-12" id="GridView" runat="server" style="overflow: scroll;">
                <asp:GridView runat="server" ID="gvTrendData" CssClass="table table-hover table-striped" AutoGenerateColumns="true" GridLines="Both">
                    <%-- <Columns>
                         <asp:BoundField DataField="DateTime" HeaderText="Vehicle No." ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Past_TempPV" HeaderText="Vehicle ID" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Past_TempSP" HeaderText="Challan No." ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Chill_TempPV" HeaderText="Driver Name" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Chill_TempSP" HeaderText="Tanker Source Location" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Hot_Valve_Status" HeaderText="Product Name" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="MPL1_Cold_Valve_Status" HeaderText="Purpose" ItemStyle-Wrap="false" />
                    </Columns>--%>
                </asp:GridView>
            </div>
            <div class="col-md-12 center" id="divNo" runat="server">No records found.</div>
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
