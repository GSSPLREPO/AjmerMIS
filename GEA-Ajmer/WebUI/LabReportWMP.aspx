<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="LabReportWMP.aspx.cs" Inherits="GEA_Ajmer.WebUI.LabReportWMP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Lab Report WMP</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row col-md-12">
            <div class="panel panel-default">
                <div id="divGrid" runat="server" class="panel panel-default">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6">
                                <h4>
                                    <asp:Label ID="lblHeading" runat="server" Text="Lab Report WMP"></asp:Label></h4>
                            </div>
                            <div class="col-md-3" style="padding-left: 20px;">
                                <div class="input-group ">
                                    <span id='search-icon' class="input-group-addon"><span class='glyphicon glyphicon-search'></span></span>
                                    <input id="id_search" type="text" class="form-control" placeholder="Type here" onkeydown=" return (event.keyCode !== 13); " />
                                </div>
                            </div>
                            <div class="col-md-1 right">
                                <asp:Button runat="server" ID="btnAddNew" Text="Add New" CssClass="btn btn-warning pull-right btn-addnew" OnClick="btnAddNew_OnClick" data-original-title="Select Project" data-placement="bottom" data-toggle="tooltip" ToolTip="Add New"></asp:Button>
                            </div>
                            <div class="col-md-2 right" id="divExport" runat="server">
                                <asp:LinkButton ID="imgPdfButton" runat="server" CssClass="btn btn-danger quick-btn" OnClick="imgPdfButton_Click"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                                <asp:LinkButton ID="imgExcelButton" runat="server" OnClick="imgbtnExcel_OnClick" CssClass="btn btn-success quick-btn"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
<%--                                <asp:LinkButton ID="imgWordButton" runat="server" OnClick="imgbtnWord_OnClick" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>--%>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body" style="overflow: scroll;">
                        <asp:GridView runat="server" ID="gvLabReportWMP" CssClass="table table-hover table-striped" Width="100%" AutoGenerateColumns="False" GridLines="None"
                            OnPreRender="gvLabReportWMP_OnPreRender" OnRowCommand="gvLabReportWMP_OnRowCommand">
                            <Columns>
                                <asp:BoundField DataField="SrNo" HeaderText="Sr No" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="TypeOfPowder" HeaderText="Type Of Powder" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="Time" HeaderText="Time" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="Batchno" HeaderText="Batch no" ItemStyle-Width="10%" HeaderStyle-Width="20%" />
                                <asp:BoundField DataField="BagNo" HeaderText="Bag No" ItemStyle-Width="10%" HeaderStyle-Width="20%" />
                                <asp:BoundField DataField="Weight" HeaderText="Weight" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="Appearance" HeaderText="Appearance" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="Moisture" HeaderText="Moisture" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="TotalSolid" HeaderText="Total solids" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="BulkDensity" HeaderText="Bulk density" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="MilkFat" HeaderText="Milk Fat" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="Acidity" HeaderText="Acidity LA" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="Wettability" HeaderText="Wettability" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="ScorchedParticle" HeaderText="Scorched particle" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="SolIndex" HeaderText="Sol Index (MI)" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="CoffeTest" HeaderText="Coffee Test" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="Flavour" HeaderText="Flavour" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="Protein" HeaderText="Protein (%)" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="ASH" HeaderText="Ash (%)" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="Lumpiness" HeaderText="Lumpiness" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="Adultration" HeaderText="Adultration" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="UserId" HeaderText="User Id" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgEdit" CommandName="Edit1" CommandArgument='<%# Eval("Id") %>' HeaderStyle-Width="10%" ItemStyle-Width="10%" ImageUrl="../images/Edit.png"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgDelete" CommandName="Delete1" CommandArgument='<%# Eval("Id") %>' HeaderStyle-Width="10%" ItemStyle-Width="10%" ImageUrl="../images/Delete.png" OnClientClick="javascript:return confirm('Do you really want to Delete this record?');"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="panel-body" id="divPanel" runat="server">
                    <div class="row" style="margin-bottom: 17px;">
                        <div class="form-group has-error">
                            <label class="col-md-2">Date :</label>
                            <div class="col-md-4">
                                <div class='input-group date' id='datetimepicker1'>
                                    <asp:TextBox ID="txtDate" CssClass="fromdate form-control" Placeholder="Date" runat="server"></asp:TextBox>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>

                                </div>
                            </div>
                            <div class="form-group has-error">
                                <label class="col-md-2">Time :</label>
                                <div class="col-md-4">
                                    <div class="input-group bootstrap-timepicker">
                                        <asp:TextBox ID="txtTime" ClientIDMode="Static" CssClass="form-control timepicker" Placeholder="Time" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group has-error">
                            <label class="col-md-2">Type of Powder</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtTypeofPowder" CssClass="form-control" placeholder="Enter Type of Powder" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTypeofPowder" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Type Of Powder" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group has-error">
                                <label class="col-md-2">Weight</label>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtWeight" ClientIDMode="Static" CssClass="form-control" Placeholder="Enter Weight" runat="server" onkeypress="return PreventDecimalPointValue(event)"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtWeight" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter Weight" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 20px;">
                        <div class="form-group has-error">
                            <label class="col-md-2">Batch no</label>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <asp:TextBox ID="txtBatchNo" ClientIDMode="Static" CssClass="form-control" Placeholder="Enter Batch no" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBatchNo" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter Batch no" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group has-error">
                                <label class="col-md-2">Bag Nos</label>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBagNos" ClientIDMode="Static" CssClass="form-control" Placeholder="Enter Bag No" runat="server" onkeypress="return PreventDecimalPoint(event)"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtBagNos" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter Bag no" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="form-group has-error">
                            <label class="col-md-2">Appearance (Colour)</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtAppearance" CssClass="form-control" placeholder="Enter Appearance (Colour)" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAppearance" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Appearance (Colour)" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group has-error">
                                <label class="col-md-2">Moisture % by mass</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtMoisture" CssClass="form-control" placeholder="Enter Moisture % by mass" onkeypress="return PreventDecimalPointValue(event)" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMoisture" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter Moisture % by mass" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 20px;">
                        <div class="form-group has-error">
                            <label class="col-md-2">Total solids % by mass</label>
                            <div class="col-md-4 has-error">
                                <asp:TextBox ID="txtTotalSolids" CssClass="fromdate form-control" Placeholder="Enter Total solids % by mass" runat="server" onkeypress="return PreventDecimalPointValue(event)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtTotalSolids" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Total solids % by mass" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2">Bulk density G/cc</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtBulkDensity" CssClass="fromdate form-control" Placeholder="Enter Bulk density G/cc" runat="server" onkeypress="return PreventDecimalPointValue(event)"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtBulkDensity" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter Bulk density G/cc" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="form-group ">
                            <label class="col-md-2">Milk Fat % by mass</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtMilkFat" CssClass="form-control" placeholder="Enter Milk Fat % by mass" onkeypress="return PreventDecimalPointValue(event)" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtMilkFat" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Milk Fat % by mass" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2">Acidity LA</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtAcidity" CssClass="form-control" placeholder="Enter Acidity LA" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtAcidity" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter Acidity LA" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="form-group ">
                            <label class="col-md-2">Wettability</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtWettability" CssClass="form-control" placeholder="Enter Wettability" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtWettability" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Wettability" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2">Scorched particle</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtScorchedparticle" CssClass="form-control" placeholder="Enter Scorched particle" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtScorchedparticle" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter Scorchedparticle" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="form-group ">
                            <label class="col-md-2">Sol Index (MI)</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtSolIndex" CssClass="form-control" placeholder="Enter Sol Index (MI)" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtSolIndex" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Scorchedparticle" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2">Coffee Test</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtCoffeeTest" CssClass="form-control" placeholder="Enter Coffee Test" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtCoffeeTest" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter Coffee Test" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="form-group ">
                            <label class="col-md-2">Flavour</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtFlavour" CssClass="form-control" placeholder="Enter Flavour" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtFlavour" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Flavour" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2">Protein (%)</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtProtein" CssClass="form-control" placeholder="Enter Protein (%)" onkeypress="return PreventDecimalPointValue(event)" />
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtProtein" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Protein (%)" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="form-group ">
                            <label class="col-md-2">Ash (%)</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtAsh" CssClass="form-control" placeholder="Enter Ash (%)" onkeypress="return PreventDecimalPointValue(event)" />
                                <%--     <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtAsh" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Ash (%)" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2">Lumpiness</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtLumpiness" CssClass="form-control" placeholder="Enter Lumpiness" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtLumpiness" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter Lumpiness" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="form-group ">
                            <label class="col-md-2">Adultration</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtAdultration" CssClass="form-control" placeholder="Enter Adultration" />
                            </div>
                        </div>
                        <div class="form-group ">
                            <label class="col-md-2"></label>
                            <div class="col-md-4">
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer text-right">
                        <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="g1" CssClass="btn btn-sm btn-success" OnClick="btnSave_OnClick"></asp:Button>
                        <asp:Button runat="server" ID="Button2" Text="Viewlist" CssClass="btn btn-primary" OnClick="btnViewList_OnClick" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDate" ValidationGroup="g1"
                            SetFocusOnError="True" ErrorMessage="Enter Date" ForeColor="Red">*</asp:RequiredFieldValidator>

                        <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="g1" ShowMessageBox="True" ShowSummary="False" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#id_search').quicksearch('table#<%=gvLabReportWMP.ClientID%> tbody tr');
        });
    </script>
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
    </script>
</asp:Content>

