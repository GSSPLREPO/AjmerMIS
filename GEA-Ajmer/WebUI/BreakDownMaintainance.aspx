<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="BreakDownMaintainance.aspx.cs" Inherits="GEA_Ajmer.WebUI.BreakDownMaintainance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx"> Home</a></li>
            <li class="active"><i class="fa fa-file"></i> Breakdown Maintainance </li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row col-md-12">
            <div class="panel panel-default">
                <div id="divGrid" runat="server" class="panel panel-default">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-5">
                                <h4>
                                    <asp:Label ID="lblHeading" runat="server" Text="Breakdown Maintainance"></asp:Label></h4>
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
                            <div class="col-md-3 right" id="divExport" runat="server">
                                <asp:LinkButton ID="imbtnPDFButton" runat="server" OnClick="imbtnPDFButton_Click" CssClass="btn btn-danger quick-btn"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                                <asp:LinkButton ID="imgExcelButton" runat="server" OnClick="imgbtnExcel_OnClick" CssClass="btn btn-success quick-btn"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                                <asp:LinkButton ID="imgWordButton" runat="server" OnClick="imgbtnWord_OnClick" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <%--table table-hover table-striped--%>
                    <div class="panel-body" style="overflow: scroll;">
                        <asp:GridView runat="server" ID="gvBreakdownMaintainance" CssClass="table table-striped"
                            AutoGenerateColumns="false" GridLines="Both"
                            OnPreRender="gvBreakdownMaintainance_OnPreRender"
                            OnRowCommand="gvBreakdownMaintainance_OnRowCommand">
                            <Columns>
                                <asp:BoundField HeaderText="Sr No." DataField="SrNo" />
                                <asp:BoundField HeaderText="Maintainance Date" DataField="MaintainanceDate" />
                                <asp:BoundField HeaderText="Start Time" DataField="StartTime" />
                                <asp:BoundField HeaderText="End Time" DataField="EndTime" />
                                <asp:BoundField HeaderText="Equipment Tag No" DataField="EquipmentTagNo" />
                                <asp:BoundField HeaderText="Equipment Name" DataField="EquipmentName" />
                                <asp:BoundField HeaderText="Part No" DataField="PartNo" />
                                <asp:BoundField HeaderText="Part Name" DataField="PartName" />
                                <asp:BoundField HeaderText="Area" DataField="Area" />
                                <asp:BoundField HeaderText="Dept." DataField="Department" />
                                <asp:BoundField HeaderText="Section" DataField="Section" />
                                <asp:BoundField HeaderText="Cause" DataField="Cause" />
                                <asp:BoundField HeaderText="Details of breakdown" DataField="DetailBreakDown" />
                                <asp:BoundField HeaderText="Action Taken" DataField="ActionTaken" />
                                <asp:BoundField HeaderText="Rectified By" DataField="RectifiedBy" />
                                <asp:BoundField HeaderText="Remark" DataField="Remark" />
                                <asp:BoundField HeaderText="UserName" DataField="Name" />
                                <asp:BoundField HeaderText="Status" DataField="Status" />
                                <asp:TemplateField HeaderText="Change Status">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgStatus" CommandName="Status1" CommandArgument='<%# Eval("Id") %>' ImageUrl="../images/Status.png" OnClientClick="javascript:return confirm('Do you really want to Change the Status?');"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgEdit" CommandName="Edit1" CommandArgument='<%# Eval("Id") %>' ImageUrl="../images/Edit.png"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgDelete" CommandName="Delete1" CommandArgument='<%# Eval("Id") %>' ImageUrl="../images/Delete.png" OnClientClick="javascript:return confirm('Do you really want to Delete this record?');"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="panel-body" id="divPanel" runat="server">
                    <div class="row" style="margin-bottom: 17px;">
                        <div class="form-group has-error">
                            <label class="col-md-2">Maintainance Date :</label>
                            <div class="col-md-4">
                                <div class='input-group date' id='datetimepicker1'>
                                    <asp:TextBox ID="txtMaintainanceDate" CssClass="fromdate form-control" Placeholder="Maintainance Date" runat="server"></asp:TextBox>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                </div>
                            </div>
                        </div>
                    </div>
                     <div class="row" style="margin-bottom: 20px;">
                        <div class="form-group has-error">
                            <label class="col-md-2">Start Time :</label>
                            <div class="col-md-4">
                                <div class="input-group bootstrap-timepicker">
                                    <asp:TextBox ID="txtStartDate" ClientIDMode="Static" CssClass="form-control timepicker" Placeholder="From Time" runat="server"></asp:TextBox>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                </div>
                            </div>
                            <div class="form-group has-error">
                                <label class="col-md-2">End Time :</label>
                                <div class="col-md-4">
                                    <div class="input-group bootstrap-timepicker">
                                        <asp:TextBox ID="txtEndDate" ClientIDMode="Static" CssClass="form-control timepicker" Placeholder="From Time" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group has-error">
                            <label class="col-md-2">Equipment No :</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtEquipmentNo" CssClass="form-control" placeholder="Enter Equipment No" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEquipmentNo" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Equipment No" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group has-error">
                                <label class="col-md-2">Equipment Name :</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtEquipmentName" CssClass="form-control" placeholder="Enter Equipment Name" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEquipmentName" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter Equipment Name" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                   
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="form-group">
                            <label class="col-md-2">Part No :</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtPartNo" CssClass="form-control" placeholder="Enter Part No" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPartNo" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Part No" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2">Part Name :</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtPartName" CssClass="form-control" placeholder="Enter Part Name" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPartName" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter Part Name" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                      <div class="row" style="margin-bottom: 15px;">
                        <div class="form-group ">
                            <label class="col-md-2">Area :</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtArea" CssClass="form-control" placeholder="Enter Area" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtArea" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Area" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2">Department:</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtDepartment" CssClass="form-control" placeholder="Enter Department" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtDepartment" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter Department" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 20px;">
                        <div class="form-group ">
                             <label class="col-md-2">Section :</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtSection" CssClass="form-control" placeholder="Enter Section" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtSection" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Section" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>                           
                            <div class="form-group">
                                <label class="col-md-2">Cause :</label>
                            <div class="col-md-4 has-error">
                                <asp:TextBox ID="txtCause" CssClass="fromdate form-control" Placeholder="Enter Cause" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCause" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Cause" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            </div>
                        </div>
                    </div>
                  
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="form-group ">
                           
                             <label class="col-md-2">Details of Breakdown :</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtDetailBreakdown" CssClass="fromdate form-control" TextMode="MultiLine" Placeholder="Enter Details of Break Down" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtDetailBreakdown" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter Details of Break Down" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            <div class="form-group">
                                <label class="col-md-2">Action Taken :</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtAction" CssClass="form-control" placeholder="Enter Action" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtAction" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter Action" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group ">
                            <label class="col-md-2">Rectified By :</label>
                            <div class="col-md-4 has-error">
                                <asp:TextBox runat="server" ID="txtRectified" CssClass="form-control" placeholder="Enter Rectified By Name" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtRectified" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Rectified By Name" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2">Remark :</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtRemark" CssClass="form-control" placeholder="Enter Remark" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer text-right">
                        <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="g1" CssClass="btn btn-sm btn-success" OnClick="btnSave_OnClick"></asp:Button>
                        <asp:Button runat="server" ID="Button2" Text="Viewlist" CssClass="btn btn-primary" OnClick="btnViewList_OnClick" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMaintainanceDate" ValidationGroup="g1"
                            SetFocusOnError="True" ErrorMessage="Enter Maintainance Date" ForeColor="Red">*</asp:RequiredFieldValidator>
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
            $('#id_search').quicksearch('table#<%=gvBreakdownMaintainance.ClientID%> tbody tr');
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
