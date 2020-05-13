<%@ Page Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="EvaporatorLogSheet.aspx.cs" Inherits="GEA_Ajmer.ReportUI.EvaporatorLogSheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx"> Home</a></li>
            <li class="active"><i class="fa fa-file"></i> Evaporator LogSheet Report</li>
        </ul>
    </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        Evaporator LogSheet Report
                    </div>
                    <div class="col-md-2 right" id="divExport" runat="server">
                        <asp:LinkButton ID="imgPdfButton" runat="server" OnClick="imgbtnPDF_OnClick" CssClass="btn btn-danger quick-btn"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="imgExcelButton" runat="server" OnClick="imgExcelButton_Click" CssClass="btn btn-success quick-btn"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
<%--                        <asp:LinkButton ID="imgWordButton" runat="server" OnClick="imgWordButton_Click" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>--%>
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
                            <asp:Button runat="server" ID="btnGo" Text="Go" CssClass="btn btn-primary pull-right" ValidationGroup="g1" OnClick="btnGo_Click" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFromDate" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter From Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtToDate" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter To Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2"></div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12" style="overflow: scroll">
                        <asp:GridView runat="server" ID="gvEvaporatorLog" CssClass="table table-hover table-striped"
                            AutoGenerateColumns="false" GridLines="Both" HeaderStyle-Wrap="false">
                            <Columns>
                                <asp:BoundField DataField="SrNo" HeaderText="Sr No" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-Wrap="false" Visible="false" />
                                <asp:BoundField DataField="Time" HeaderText="Time" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="SiloTag" HeaderText="Silo Tag" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="FeedFlow" HeaderText="Feed Flow (Kg/Hr)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="PCD01" HeaderText="PCD 01 Temp." ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="FV2HeatingTemp" HeaderText="FV-2 Heating Temp." ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="FV1HeatingTemp" HeaderText="FV-1 Heating Temp." ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="DSITemp" HeaderText="DSI Temp." ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="FV1CoolingTemp" HeaderText="FV-1 Cooling Temp." ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="FV2CoolingTemp" HeaderText="FV-2 Cooling Temp." ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Cal1Temp" HeaderText="Cal 1 Temp" ItemStyle-Wrap="false" />
                                <%--<asp:BoundField DataField="VS1Temp" HeaderText="VS-1 Temp" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="VS2Temp" HeaderText="VS-2 Temp" ItemStyle-Wrap="false" />--%>
                                <asp:BoundField DataField="Cal3Temp" HeaderText="Cal 3 Temp" ItemStyle-Wrap="false" />
                                <%--<asp:BoundField DataField="VS3Temp" HeaderText="VS-3 Temp" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="VS4Temp" HeaderText="VS-4 Temp" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="VS3Temp" HeaderText="VS-5 Temp" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="VS3Temp" HeaderText="VS-5 Temp" ItemStyle-Wrap="false" />--%>
                                <asp:BoundField DataField="CondenserCWInTemp" HeaderText="Condenser CW In Temp." ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="CondenserCWOutTemp" HeaderText="Condenser CW Out Temp." ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="CondenserTemp" HeaderText="Condenser Temp." ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="PlantVacuum" HeaderText="Plant Vacuum" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="TVR01Pressure" HeaderText="TVR 01 Pressure" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="TVR02Pressure" HeaderText="TVR 02 Pressure" ItemStyle-Wrap="false" />
                                <%--<asp:BoundField DataField="TVR03Pressure" HeaderText="TVR 03 Pressure" ItemStyle-Wrap="false" />--%>
                                <asp:BoundField DataField="DSIPressure" HeaderText="DSI Pressure" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="CondensateCond" HeaderText="Condensate Cond." ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="FinalConcFlow" HeaderText="Final Conc. Flow" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="FinalConcDensity" HeaderText="Final Conc. Density" ItemStyle-Wrap="false" />
                                <%--<asp:BoundField DataField="FinalProductLineCond" HeaderText="Final Product Line Cond." ItemStyle-Wrap="false" />--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="col-md-12 center" id="divNo" runat="server">No records found.</div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        var date = new Date();
        var end = new Date(date.getFullYear(), date.getMonth(), date.getDate());
        var today = new Date(date.getFullYear(), date.getMonth(), date.getDate());
        $('#datetimepicker1 input').datepicker({
            clearBtn: true,
            format: 'dd/mm/yyyy',
            autoclose: true,
            orientation: "top auto",
            endDate: end
        });
        $('#datetimepicker2 input').datepicker({
            clearBtn: true,
            format: 'dd/mm/yyyy',
            autoclose: true,
            orientation: "top auto",
            endDate: end
        });
        $('datetimepicker1').datepicker('setDate', today);
        $('datetimepicker2').datepicker('setDate', today);
    </script>
</asp:Content>
