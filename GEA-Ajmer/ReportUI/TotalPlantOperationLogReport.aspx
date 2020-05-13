<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="TotalPlantOperationLogReport.aspx.cs" Inherits="GEA_Ajmer.ReportUI.TotalPlantOperationLogReport" %>



<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Total Plant Operation Log Report</li>
        </ul>
    </div>

    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        Total Plant Operation Log Report
                    </div>
                    <div class="col-md-2 right" id="divExport" runat="server">
                        <asp:LinkButton ID="imgPDFButton" runat="server" OnClick="imgPDFButton_Click" CssClass="btn btn-danger quick-btn"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="imgExcelButton" runat="server" OnClick="imgExcelButton_Click" CssClass="btn btn-success quick-btn"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="imgWordButton" runat="server" OnClick="imgWordButton_Click" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>
                    </div>
                </div>
            </div>

            <div class="panel-body">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3">
                            From Date :
                        </div>
                        <div class="col-md-2">
                            From Time :
                        </div>
                        <div class="col-md-3">
                            To Date :
                        </div>
                        <div class="col-md-2">
                            To Time :
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3 has-error">
                            <div class='input-group date' id='datetimepicker1'>
                                <asp:TextBox ID="txtFromDate" CssClass="form-control" Placeholder="From Date" runat="server"  ></asp:TextBox>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                        </div>
                        <div class="col-md-2">
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
                                <asp:TextBox ID="txtToDate" CssClass="form-control" Placeholder="To Date" runat="server"  ></asp:TextBox>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtToTime" ClientIDMode="Static" CssClass="form-control timepicker1" Placeholder="To Time" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
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
                <br />
               
                    <asp:GridView runat="server" ID="gvPlantOperation" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="Both">
                        <Columns>
                            <asp:BoundField DataField="PasteuriserName" HeaderText="Pasteuriser Name" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="TotalCIPTime" HeaderText="Total CIP Time" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="TotalProductionTime" HeaderText="Total Production Time" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="TotalRecirculationTime" HeaderText="Total Recirculation Time" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="TotalIdleTime" HeaderText="Total Idle Time" ItemStyle-Wrap="false" />
                        </Columns>

                    </asp:GridView>
               

                <div class="center" id="divId" runat="server">No records found.</div>
                <%-- <div class="col-md-12 center" id="divNo" runat="server">
                    No records found.
                </div>--%>
                <%-- <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary pull-right" OnClick="btnSave_OnClick" />--%>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">


        $("[id*=chkHeader]").bind("click", function () {
            var chkHeader = $(this);

            //Find and reference the GridView.
            var grid = $(this).closest("table");

            //Loop through the CheckBoxes in each Row.
            $("td", grid).find("input[type=checkbox]").each(function () {

                //If Header CheckBox is checked.
                //Then check all CheckBoxes and enable the TextBoxes.
                if (chkHeader.is(":checked")) {
                    $(this).attr("checked", "checked");
                    var td = $("td", $(this).closest("tr"));
                    td.css({ "background-color": "#D8EBF2" });
                    //  $("input[type=text]", td).removeAttr("disabled");
                } else {
                    $(this).removeAttr("checked");
                    var td = $("td", $(this).closest("tr"));
                    td.css({ "background-color": "#FFF" });
                    //  $("input[type=text]", td).attr("disabled", "disabled");
                }
            });
        });

       
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
