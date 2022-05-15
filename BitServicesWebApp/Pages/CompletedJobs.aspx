<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompletedJobs.aspx.cs" Inherits="BitServicesWebApp.Pages.CompletedJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <h2>All Completed Jobs</h2>
    <div id="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="../Images/book-online.jpg" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>All your Jobs</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mx-auto">
                                <asp:GridView ID="gvCompletedJobs"
                                    CssClass="table table-striped table-bordered"
                                    runat="server" OnrowCommand="gvCompletedJobs_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Approve Action">
                                            <ItemTemplate>
                                                <asp:Button ID="approveBtn" runat="server" Height="40px" Width="80px" Text="Accept" CommandName="Approve" CommandArgument="<%#Container.DataItemIndex %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Reject Action">
                                            <ItemTemplate>
                                                <asp:Button ID="rejectBtn" runat="server" Height="40px" Width="80px" Text="Reject" CommandName="Reject" CommandArgument="<%#Container.DataItemIndex %>" />
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
</asp:Content>