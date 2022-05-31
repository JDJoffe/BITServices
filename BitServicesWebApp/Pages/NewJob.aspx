<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewJob.aspx.cs" Inherits="BitServicesWebApp.Pages.NewJob" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150" src="../Images/book.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>New Job Request</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-3">
                                <label>Street</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="streetTxt" runat="server" placeholder="Street" />
                                </div>
                            </div>
                            <div class="col-3">
                                <label>Suburb</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="suburbTxt" runat="server" placeholder="Suburb" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-3">
                                <label>Job Date</label>
                                <div class="form-group">
                                    <asp:Calendar ID="jobDateCal" runat="server"></asp:Calendar>
                                </div>
                            </div>
                            <div class="col-1">
                                <label>Postcode</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="postCodeTxt" runat="server" placeholder="Postcode" />
                                </div>
                            </div>
                            <div class="col-1">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="stateDdl" runat="server">
                                        <asp:ListItem Text="NSW" Value="NSW" />
                                        <asp:ListItem Text="VIC" Value="VIC" />
                                        <asp:ListItem Text="ACT" Value="ACT" />
                                        <asp:ListItem Text="QLD" Value="QLD" />
                                        <asp:ListItem Text="SA" Value="SA" />
                                        <asp:ListItem Text="WA" Value="WA" />
                                        <asp:ListItem Text="NT" Value="NT" />
                                        <asp:ListItem Text="TAS" Value="TAS" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-1">
                                <label>Priority</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="priorityDdl" runat="server">
                                        <asp:ListItem Text="Low" Value="Low" />
                                        <asp:ListItem Text="Medium" Value="Medium" />
                                        <asp:ListItem Text="High" Value="High" />
                                        <asp:ListItem Text="Urgent" Value="Urgent" />
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-6">
                                <label>Job Description</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="descriptionTxt" runat="server" placeholder="Description" Height="200" TextMode="MultiLine" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
