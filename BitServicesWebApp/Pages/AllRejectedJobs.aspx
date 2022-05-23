<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllRejectedJobs.aspx.cs" Inherits="BitServicesWebApp.Pages.AllRejectedJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>All Rejected Jobs</h2>
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>All Rejected Jobs</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mx-auto">
                              <asp:GridView ID="gvRejectedJobs"
                                    CssClass="table table-striped table-bordered"
                                    runat="server" OnRowCommand="gvRejectedJobs_RowCommand">
                                
                                    <Columns>
                                        <asp:TemplateField HeaderText="Find Sessions">
                                            <ItemTemplate>
                                                <asp:Button ID="findSessionsBtn" runat="server"
                                                    Height="40px" Width="80px"
                                                    Text="Find Sessions" CommandName="Find"
                                                    CommandArgument="<%#Container.DataItemIndex %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <center>
                                        <h3>Available Sessions</h3>
                                    </center>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-12 mx-auto">
                                <asp:GridView ID="gvAvailableSessions"
                                        CssClass="table table-striped table-bordered"
                                        runat="server" OnRowCommand="gvAvailableSessions_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Confirm Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="confirmBtn" runat="server"
                                                        Height="40px" Width="80px"
                                                        Text="Confirm" CommandName="Confirm"
                                                        CommandArgument="<%#Container.DataItemIndex %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


