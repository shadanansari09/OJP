<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="JobList.aspx.cs" Inherits="OnlineJobPortal.Admin.JobList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="background-image: url('../images/bgs.jpeg'); width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">

        <div class="container pt-4 pb-4">

            <%--<div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>--%>

            <div class="btn-toolbar justify-content-between mb-3">
                <div class="btn-group">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
                <div class="input-group h-25">
                    <asp:HyperLink ID="backLink" NavigateUrl="~/Admin/ViewResume.aspx" CssClass="btn btn-secondary"
                        runat="server" Visible="false"> < Back </asp:HyperLink>
                </div>

            </div>



            <h3 class="text-center">Job List</h3>

            <div class="row mb-3 pt-sm-3">

                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered"
                        EmptyDataText="No Records to display.." AutoGenerateColumns="false" AllowPaging="true"
                        PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="JobId"
                        OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Sr.No" HeaderText="Sr.No">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>

                            <asp:BoundField DataField="Title" HeaderText="Job Title">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>

                            <asp:BoundField DataField="Vacancies" HeaderText="Vacancy">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>

                            <asp:BoundField DataField="Qualification" HeaderText="Qualification">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>

                            <asp:BoundField DataField="Experience" HeaderText="Experience">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>

                            <asp:BoundField DataField="Deadline" HeaderText="Valid Till" DataFormatString="{0: dd MMMM yyyy}">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>

                            <asp:BoundField DataField="CompanyName" HeaderText="Company">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>

                            <asp:BoundField DataField="Country" HeaderText="Country">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>

                            <asp:BoundField DataField="State" HeaderText="State">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>

                            <asp:BoundField DataField="CreatedOn" HeaderText="Posted On" DataFormatString="{0: dd MMMM yyyy}">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="EditJobBtn" runat="server" CommandName="EditJob"
                                        CommandArgument='<%# Eval("JobId") %>'>
                                        <asp:Image ID="ImgId" runat="server" ImageUrl="../assets/img/icon/EditIcon.png" Height="25px" Width="25px" />
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                            </asp:TemplateField>

                            <asp:CommandField CausesValidation="false" HeaderText="Remove" ShowDeleteButton="true"
                                DeleteImageUrl="../assets/img/icon/TrashIcon.png" ButtonType="Image">
                                <ControlStyle Height="25px" Width="25px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>


                        </Columns>

                        <HeaderStyle BackColor="#7200cf" ForeColor="White" />

                    </asp:GridView>

                </div>

            </div>
        </div>
    </div>

</asp:Content>
