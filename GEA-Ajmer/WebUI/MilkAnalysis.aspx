<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="MilkAnalysis.aspx.cs" Inherits="GEA_Ajmer.WebUI.MilkAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx"> Home</a></li>
            <li class="active"><i class="fa fa-file"></i> Milk Analysis </li>
        </ul>
    </div>
    <div id="divCurrenTabSelected" class="hidden" visible="false">Setting</div>
    <div class="col-md-12">
        <div id="divGrid" runat="server" class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-6">
                        <h4>
                            <asp:Label ID="lblHeading" runat="server" Text="Milk Analysis"></asp:Label></h4>
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
<%--                        <asp:LinkButton ID="imgWordButton" runat="server" OnClick="imgbtnWord_OnClick" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>--%>
                    </div>
                </div>
            </div>
            <div class="panel-body" style="overflow: scroll;">
                <asp:GridView runat="server" ID="gvMilkAnalysis" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None"
                    OnPreRender="gvCircuit_OnPreRender" OnRowCommand="gvMilkAnalysis_OnRowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Sr No" DataField="SrNo" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="Date" DataField="Date" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="Time" DataField="Time" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="Silo Tag" DataField="SiloName" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                       <%-- <asp:BoundField HeaderText="Vehicle No" DataField="VehicleNo" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="RouteNo" DataField="RouteNo" ItemStyle-Width="10%" HeaderStyle-Width="10%" />--%>
                        <asp:BoundField HeaderText="Product Type" DataField="ProductType" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="SampleId" DataField="SampleId" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                       <%-- <asp:BoundField HeaderText="COB" DataField="COB" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="AlcoholNo" DataField="AlcoholNo" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="Neutralizer" DataField="Neutralizer" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="Urea" DataField="Urea" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="Salt" DataField="Salt" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="Starch" DataField="Starch" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="FPD" DataField="FPD" ItemStyle-Width="10%" HeaderStyle-Width="10%" />--%>
                        <asp:BoundField DataField="FAT" HeaderText="FAT (%)" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField DataField="SNF" HeaderText="SNF (%)" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField DataField="Sugar" HeaderText="Sugar (%)" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField DataField="TS" HeaderText="TS (%)" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="Acidity" DataField="Acidity" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                         <asp:BoundField HeaderText="Temp" DataField="Temp" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="OT" DataField="OT" ItemStyle-Width="10%" HeaderStyle-Width="10%" />

                        <asp:BoundField HeaderText="User Name" DataField="Name" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="Remarks" DataField="Remark" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEdit" CommandName="Edit1" CommandArgument='<%# Eval("Id") %>' HeaderStyle-Width="25%" ItemStyle-Width="25%" ImageUrl="../images/Edit.png"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgDelete" CommandName="Delete1" CommandArgument='<%# Eval("Id") %>' HeaderStyle-Width="25%" ItemStyle-Width="25%" ImageUrl="../images/Delete.png" OnClientClick="javascript:return confirm('Do you really want to Delete this record?');"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="panel panel-default" runat="server" id="divPanel">
            <div class="panel-heading">
                <h3 class="box-title">Milk Analysis</h3>
            </div>
            <div class="panel-body">

                <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">Date</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control dtpicker" onkeypress="return false;" placeholder="Select Date" MaxLength="10"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <label class="col-md-2">Time :</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtTime" ClientIDMode="Static" CssClass="form-control timepicker" Placeholder="Time" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">Silo Tag</label>
                        <div class="col-md-4">

                            <asp:DropDownList ID="ddlSiloId" runat="server" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSiloId" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Please Select Solo Id" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>

                        </div>
                        <label class="col-md-2">Product Type </label>
                        <div class="col-md-4">

                            <asp:TextBox runat="server" ID="txtProductType" CssClass="form-control" placeholder="Enter Product Type " />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtProductType" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Product Type." ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">Sample Id</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtSampleId" CssClass="form-control" placeholder="Enter Sample ID" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSampleId" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter Sample ID" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <label class="col-md-2">Fat (%) </label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtFat" CssClass="form-control" placeholder="Enter Fat (%)" onkeypress="return PreventDecimalPointValue(event)" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFat" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter FAT" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">SNF (%)</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtSNF" CssClass="form-control" placeholder="Enter SNF (%)" onkeypress="return PreventDecimalPointValue(event)" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtSNF" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter SNF" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <label class="col-md-2">Sugar (%)</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtSugar" CssClass="form-control" placeholder="Enter Sugar (%)" onkeypress="return PreventDecimalPointValue(event)" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtSugar" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter Sugar" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">TS (%)</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtTS" CssClass="form-control" placeholder="Enter TS (%)" onkeypress="return PreventDecimalPointValue(event)" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtTS" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter txtTS" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <label class="col-md-2">Acidity</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtAcidity" CssClass="form-control" placeholder="Enter Acidity" onkeypress="return PreventDecimalPointValue(event)" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAcidity" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter Acidity" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">Temp</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtTemp" CssClass="form-control" placeholder="Enter Temp" onkeypress="return PreventDecimalPointValue(event)" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtTemp" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter Temp" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <label class="col-md-2">OT</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtOT" CssClass="form-control" placeholder="Enter OT" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtOT" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter OT" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <%-- <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">Vehicle ID</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtVehicleId" CssClass="form-control" placeholder="Enter VehicleId" onkeypress="return PreventDecimalPointValue(event)" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtVehicleId" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter VehicleId" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <label class="col-md-2">Vehicle No.</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtVehicleNo" CssClass="form-control" placeholder="Enter Vehicle No" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtVehicleNo" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter VehicleNo" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>--%>

               <%-- <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">Route No</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtRouteNo" CssClass="form-control" placeholder="Enter Route No" onkeypress="return PreventDecimalPointValue(event)" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtRouteNo" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter Route No" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <label class="col-md-2">COB</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtCob" CssClass="form-control" placeholder="Enter COB" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtCob" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter COB" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                 <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">Alcohol No</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtAlcohol" CssClass="form-control" placeholder="Enter Alcohol No" onkeypress="return PreventDecimalPointValue(event)" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtAlcohol" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter Alcohol No" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <label class="col-md-2">Neutralizer</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtNeutralizer" CssClass="form-control" placeholder="Enter Neutralizer" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtNeutralizer" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter Neutralizer" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                 <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">Urea</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtUrea" CssClass="form-control" placeholder="Enter Urea" onkeypress="return PreventDecimalPointValue(event)" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtUrea" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter Urea" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <label class="col-md-2">Salt</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtSalt" CssClass="form-control" placeholder="Enter Salt" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtSalt" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter Salt" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                 <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">Starch</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtStarch" CssClass="form-control" placeholder="Enter Starch" onkeypress="return PreventDecimalPointValue(event)" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtStarch" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter Starch" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <label class="col-md-2">FPD</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtFpd" CssClass="form-control" placeholder="Enter FPD" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtFpd" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter FPD" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>--%>

        
                <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">Remark</label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtRemark" CssClass="form-control" TextMode="MultiLine" placeholder="Enter Remark" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtRemark" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Remark" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-footer">
                <div class="row">
                    <div class="col-md-offset-10 col-md-2">
                        <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" ValidationGroup="g1" OnClick="btnSave_OnClick" />
                        <asp:Button runat="server" ID="btnViewList" Text="Viewlist" CssClass="btn btn-primary" OnClick="btnViewList_OnClick" />
                        <asp:ValidationSummary runat="server" ID="vs1" ValidationGroup="g1" ShowMessageBox="True" ShowSummary="False" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#id_search').quicksearch('table#<%=gvMilkAnalysis.ClientID%> tbody tr');
        });
        $(".dtpicker").datepicker({
            format: "dd/mm/yyyy",
            autoclose: true,
            todayHighlight: true,
            clearBtn: true,
            orientation: 'top'
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
