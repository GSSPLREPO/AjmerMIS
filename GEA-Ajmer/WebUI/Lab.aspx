<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="Lab.aspx.cs" Inherits="GEA_Ajmer.WebUI.Lab" %>
<%@ Import Namespace="GEA_Ajmer.Common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/jquery-ui.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Lab  </li>
        </ul>
    </div>
    <div class="col-md-12">
        <div id="divGrid" runat="server" class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-8">
                        <h4>
                            <asp:Label ID="lblHeading" runat="server" Text="Lab"></asp:Label></h4>
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
                </div>
            </div>
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-2">
                        From Date :
                    </div>
                    <div class="col-md-3 has-error">
                        <div class='input-group date' id='datetimepicker1'>
                            <asp:TextBox ID="txtFromDate" CssClass="fromdate form-control" Placeholder="From Date" runat="server"></asp:TextBox>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                        </div>
                    </div>
                    <div class="col-md-2">
                        To Date : 
                    </div>
                    <div class="col-md-3 has-error">
                        <div class='input-group date' id='datetimepicker2'>
                            <asp:TextBox ID="txtToDate" CssClass="fromdate form-control" Placeholder="To Date" runat="server"></asp:TextBox>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                        </div>
                    </div>
                    <div class="col-md-2 right">
                        <asp:Button runat="server" ID="btnGo" Text="Go" CssClass="btn btn-warning pull-right btn-addnew" OnClick="btnGo_OnClick" data-original-title="Select Project" data-placement="bottom" data-toggle="tooltip" ToolTip="Add New"></asp:Button>
                    </div>
                </div>
            </div>
            <%--<div class="panel-heading">
                <div class="row">
                    <div class="col-md-4">
                        
                    </div>
                    <div class="col-md-4" style="vertical-align: middle; text-align: center;">
                        <div class="input-group ">
                            <span id='search-icon' class="input-group-addon"><span class='glyphicon glyphicon-search'></span></span>
                            <input id="id_search" type="text" class="form-control" placeholder="Type here" onkeydown=" return (event.keyCode !== 13); " />
                        </div>
                    </div>
                    <div class="col-md-2">
                        
                    </div>
                    <div class="col-md-2 right" style="padding-right: 20px; text-align: right;">
                        <asp:LinkButton ID="imgbtnPDF" runat="server" OnClick="imgbtnPDF_OnClick" CssClass="btn btn-danger quick-btn"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="imgbtnExcel" runat="server" OnClick="imgbtnExcel_OnClick" CssClass="btn btn-success quick-btn"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="imgbtnWord" runat="server" OnClick="imgbtnWord_OnClick" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>
                    </div>
                </div>
            </div>--%>
            <div class="panel-heading">
                <asp:GridView runat="server" ID="gvLabReport" CssClass="table table-striped" AutoGenerateColumns="False" GridLines="None" OnPreRender="gvLabReport_OnPreRender" OnRowCommand="gvLabReport_OnRowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Date" DataField="LabDate" />
                        <asp:BoundField HeaderText="VehicleID" DataField="VehicleCode" />
                        <asp:BoundField HeaderText="Vehicle No." DataField="VehicleNumber" />
                        <asp:BoundField HeaderText="Route" DataField="RouteNo" />
                        <asp:BoundField HeaderText="Product Name" DataField="ProductName" />
                        <asp:BoundField HeaderText="OT" DataField="OT" />
                        <asp:BoundField HeaderText="Temp" DataField="Temp" />
                        <asp:BoundField HeaderText="Fat" DataField="Fat" />
                        <asp:BoundField HeaderText="SNF" DataField="SNF" />
                        <asp:BoundField HeaderText="Acidity" DataField="Acidity" />
                        <asp:BoundField HeaderText="COB" DataField="COB" />
                        <asp:BoundField HeaderText="Alcohol No" DataField="AlcoholNo" />
                        <asp:BoundField HeaderText="Neutralizer" DataField="Neutralizer" />
                        <asp:BoundField HeaderText="Urea" DataField="Urea" />
                        <asp:BoundField HeaderText="Salt" DataField="Salt" />
                        <asp:BoundField HeaderText="Startch" DataField="Startch" />
                        <asp:BoundField HeaderText="FPD" DataField="FPD" />
                        <asp:BoundField HeaderText="Status" DataField="Status" />
                        <asp:BoundField HeaderText="User" DataField="Name" />
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEdit" CommandName="Edit1" CommandArgument='<%# Eval("Id") %>' ImageUrl="../images/Edit.png"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="imgDelete" CommandName="Delete1" CommandArgument='<%# Eval("Id") %>' HeaderStyle-Width="5%" ItemStyle-Width="5%" ImageUrl="../images/Delete.png" OnClientClick="javascript:return confirm('Do you really want to Delete this record?');"></asp:ImageButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

    </div>
    <div class="panel panel-default" runat="server" id="divPanel">
        <div class="panel-heading">
            <h3 class="box-title">Lab </h3>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group has-error">
                        <div class="col-md-2">
                            Date : 
                        </div>
                        <div class="col-md-3 has-error">
                            <div class='input-group date' id='datetimepicker3'>
                                <asp:TextBox ID="txtLabDate" CssClass="fromdate form-control" Placeholder="Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLabDate" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2">
                            VehicleId : 
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtVehicleId" CssClass="fromdate form-control" Placeholder="Vehicle Id" runat="server"></asp:TextBox>
                           
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group has-error">
                        <div class="col-md-2">
                            Vehicle No. : 
                        </div>
                        <div class="col-md-3 has-error">
                            <asp:TextBox ID="txtVehicleNo" CssClass="fromdate form-control autosuggest" Placeholder="Vehicle No" runat="server"></asp:TextBox>
                            <asp:HiddenField ID="hfVehicleId" runat="server" />
                            <asp:HiddenField ID="hfVehicleNo" runat="server" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtVehicleNo" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Vehicle number" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2">
                            Route No : 
                        </div>
                        <div class="col-md-3 has-error">
                            <asp:TextBox ID="txtRouteNo" CssClass="fromdate form-control" Placeholder="Fat" runat="server" ></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group ">
                        <div class="col-md-2 has-error">
                            Product Name : 
                        </div>
                        <div class="col-md-3 has-error">
                            <asp:DropDownList runat="server" ID="ddlProduct" CssClass="form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlProduct" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Select Product" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2">
                            OT : 
                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList runat="server" ID="ddlOT" CssClass="form-control">
                                <asp:ListItem Value="-1">-Select-</asp:ListItem>
                                <asp:ListItem Value="1">Ok</asp:ListItem>
                                <asp:ListItem Value="2">Not Ok</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="margin-bottom: 20px;">
                <div class="col-md-12">
                    <div class="form-group">
                        <div class="col-md-2">
                            Temp('c) : 
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtTemp" CssClass="fromdate form-control" Placeholder="Temp" runat="server" onkeypress="return NumericKeyPressFraction(event);"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            FAT(%) : 
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtFat" CssClass="fromdate form-control" Placeholder="Fat" runat="server" onkeypress="return NumericKeyPressFraction(event);"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="margin-bottom: 20px;">
                <div class="col-md-12">
                    <div class="form-group">
                        <div class="col-md-2">
                            SNF(%) : 
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtSNF" CssClass="fromdate form-control" Placeholder="SNF" runat="server" onkeypress="return NumericKeyPressFraction(event);"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            Acidity(%) : 
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtAcidity" CssClass="fromdate form-control" Placeholder="Acidity" runat="server" onkeypress="return NumericKeyPressFraction(event);"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="margin-bottom: 20px;">
                <div class="col-md-12">
                    <div class="form-group">
                        <div class="col-md-2">
                            COB : 
                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList runat="server" ID="ddlCOB" CssClass="form-control">
                                <asp:ListItem Value="-1">-Select-</asp:ListItem>
                                <asp:ListItem Value="+Ve">+Ve</asp:ListItem>
                                <asp:ListItem Value="-Ve">-Ve</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            Alcohol No. : 
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtAlcoholNo" CssClass="fromdate form-control" Placeholder="Alcohol No" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="margin-bottom: 20px;">
                <div class="col-md-12">
                    <div class="form-group">
                        <div class="col-md-2">
                            Neutralizer : 
                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList runat="server" ID="ddlNeutralizer" CssClass="form-control">
                                <asp:ListItem Value="-1">-Select-</asp:ListItem>
                                <asp:ListItem Value="+Ve">+Ve</asp:ListItem>
                                <asp:ListItem Value="-Ve">-Ve</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            Urea : 
                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList runat="server" ID="ddlUrea" CssClass="form-control">
                                <asp:ListItem Value="-1">-Select-</asp:ListItem>
                                <asp:ListItem Value="+Ve">+Ve</asp:ListItem>
                                <asp:ListItem Value="-Ve">-Ve</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="margin-bottom: 20px;">
                <div class="col-md-12">
                    <div class="form-group">
                        <div class="col-md-2">
                            Salt : 
                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList runat="server" ID="ddlSalt" CssClass="form-control">
                                <asp:ListItem Value="-1">-Select-</asp:ListItem>
                                <asp:ListItem Value="+Ve">+Ve</asp:ListItem>
                                <asp:ListItem Value="-Ve">-Ve</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            Startch : 
                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList runat="server" ID="ddlStartch" CssClass="form-control">
                                <asp:ListItem Value="-1">-Select-</asp:ListItem>
                                <asp:ListItem Value="+Ve">+Ve</asp:ListItem>
                                <asp:ListItem Value="-Ve">-Ve</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="margin-bottom: 20px;">
                <div class="col-md-12">
                    <div class="form-group">
                        <div class="col-md-2">
                            FPD : 
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtFPD" CssClass="fromdate form-control" Placeholder="FPD" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-2 ">
                            Status : 
                        </div>
                        <div class="col-md-3 has-error">
                            <asp:DropDownList runat="server" ID="ddlStatus" CssClass="form-control">
                                <asp:ListItem Value="-1">-Select-</asp:ListItem>
                                <asp:ListItem Value="1">Accepted</asp:ListItem>
                                <asp:ListItem Value="2">Rejected</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlStatus" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Select Status" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#id_search').quicksearch('table#<%=gvLabReport.ClientID%> tbody tr');
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
        $('#datetimepicker3 input').datepicker({
            clearBtn: true,
            format: 'dd/mm/yyyy',
            autoclose: true,
            orientation: "top auto"
        });

        $(document).ready(function () {
            $(".autosuggest").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Lab.aspx/GetVehicleNo",
                        data: "{'prefixText':'" + request.term + "'}",
                        dataType: "json",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('~')[0],
                                    val: item.split('~')[1],
                                    nm : item.split('~')[2]
                                };
                            }));
                        },
                        error: function () {
                            alert("Error");
                        }
                    });
                },
                select: function (e, i) {
                    $("#<%=hfVehicleId.ClientID %>").val(i.item.val);
                    $("#<%=hfVehicleNo.ClientID %>").val(i.item.label);
                    $("#<%=txtRouteNo.ClientID%>").val(i.item.nm);
                }
            });
        });
    </script>
</asp:Content>
