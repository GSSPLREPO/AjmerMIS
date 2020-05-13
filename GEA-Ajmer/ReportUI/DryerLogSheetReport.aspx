<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="DryerLogSheetReport.aspx.cs" Inherits="AMULFED.ReportUI.DryerLogSheetReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx"> Home</a></li>
            <li class="active"><i class="fa fa-file"></i> Dryer LogSheet Report</li>
        </ul>
    </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        Dryer LogSheet Report
                    </div>
                    <div class="col-md-2 right" id="divExport" runat="server">
                        <asp:LinkButton ID="imgPdfButton" runat="server" CssClass="btn btn-danger quick-btn" OnClick="imgPdfButton_Click"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
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
                            <asp:Button runat="server" ID="btnGo" Text="Go" CssClass="btn btn-primary pull-right" ValidationGroup="g1" OnClick="btnGo_Click1" />
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
                        <asp:GridView runat="server" ID="gvDryerLog" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="Both" HeaderStyle-Wrap="false">
                            <Columns>
                                <asp:BoundField DataField="SrNo" HeaderText="Sr No." ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-Wrap="false" Visible="false" />
                                <asp:BoundField DataField="Time" HeaderText="Time" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="HomogenizerInletPressure" HeaderText="Homogenizer Inlet Pressure (bar)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="HomogenizerFreq" HeaderText="Homogenizer Freq. (Hz)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="HomogenizerOutletPressure" HeaderText="Homogenizer Outlet Pressure (bar)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="DryerFeedTemp" HeaderText="Dryer Feed Temp." ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="DryingChamberVacuum" HeaderText="Drying Chamber Vacuum (mmHg)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="ExhaustFanFreq" HeaderText="Exhaust Fan Freq. (Hz)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="VibroVacuum" HeaderText="Vibro Vacuum (mmHg)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="MainAirSupplyFlow" HeaderText="Main Air Supply Flow (kg/hr)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="MainAirSupplyFanFreq" HeaderText="Main Air Supply Fan Freq. (Hz)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="AirDisperserTemp" HeaderText="Air Disperser Temp. (°C)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="MainAirSupplyTemp" HeaderText="Main Air Supply Temp. (°C)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="VF1&2AirSupplyTemp" HeaderText="VF-1 & 2 Air Supply Temp. (°C)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="VF-3AirSupplyTemp" HeaderText="VF-3 Air Supply Temp. (°C)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="VF-4AirSupplyTemp" HeaderText="VF-4 Air Supply Temp. (°C)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="VibroOutletTemp" HeaderText="Vibro Outlet Temp. (°C)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="DryingChamberOutletTemp" HeaderText="Drying Chamber Outlet Temp. (°C)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="SFBAirSupplyTemp" HeaderText="SFB Air Supply Temp. (°C)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="SFBTemp" HeaderText="SFB Temp. (°C)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="SFBDPT" HeaderText="SFB DPT. (bar)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="SFBFanFreq" HeaderText="SFB Fan Freq. (bar)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Cyclone1DPT" HeaderText="Cyclone 1 DPT. (bar)" ItemStyle-Wrap="false" />
                                <asp:BoundField DataField="Cyclone2DPT" HeaderText="Cyclone 2 DPT. (bar)" ItemStyle-Wrap="false" />
                                <%--<asp:BoundField DataField="PowderMoisture" HeaderText="Powder Moisture" ItemStyle-Wrap="false" />--%>
                                <%--<asp:BoundField DataField="BagNo" HeaderText="Bag No." ItemStyle-Wrap="false" />--%>
                                <asp:TemplateField HeaderText="Powder Moisture">
                                    <ItemTemplate>
                                        <asp:TextBox ID="PowderMoisture" runat="server" placeholder="Powder Moisture" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bag No.">
                                    <ItemTemplate>
                                        <asp:TextBox ID="BagNo" runat="server" placeholder="Bag No."/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="col-md-12 center" id="divNo" runat="server">No records found.</div>

                <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary pull-right" OnClick="btnSave_Click" />
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
