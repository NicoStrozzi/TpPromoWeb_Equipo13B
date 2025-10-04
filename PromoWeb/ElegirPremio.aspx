<%@ Page Title="Elegir Premio" Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master" CodeBehind="ElegirPremio.aspx.cs" Inherits="PromoWeb.ElegirPremio" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

  <h2 class="text-center my-4">Elegí tu premio</h2>

  <div class="row">
    <asp:Repeater ID="repPremios" runat="server" OnItemDataBound="repPremios_ItemDataBound">
      <ItemTemplate>
        
        <div class="col-12 col-sm-6 col-md-4 mb-4 d-flex justify-content-center">
          <div class="card shadow-sm" style="width:18rem;">

            <!-- Carrusel -->
            <div id="carousel_<%# Eval("Id") %>" class="carousel slide" data-bs-ride="carousel">
              <div class="carousel-inner">

                <!-- Repeater interno de imágenes -->
                <asp:Repeater ID="repImagenes" runat="server">
                  <ItemTemplate>
                    <!-- Marcamos 'active' -->
                    <div class='<%# Container.ItemIndex == 0 ? "carousel-item active" : "carousel-item" %>'>
                      <img src='<%# Container.DataItem %>'
                           class="d-block w-100"
                           alt="Imagen del premio"
                           style="height:180px; object-fit:contain;" />
                    </div>
                  </ItemTemplate>
                </asp:Repeater>

              </div>

              <button class="carousel-control-prev" type="button"
                      data-bs-target="#carousel_<%# Eval("Id") %>" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Anterior</span>
              </button>
              <button class="carousel-control-next" type="button"
                      data-bs-target="#carousel_<%# Eval("Id") %>" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Siguiente</span>
              </button>
            </div>

            <div class="card-body text-center d-flex flex-column">
              <h5 class="card-title mb-2"><%# Eval("Nombre") %></h5>
              <p class="card-text mb-3" style="min-height:64px;"><%# Eval("Descripcion") %></p>

              <asp:Button ID="btnElegir" runat="server"
                          Text="Elegir este premio"
                          CssClass="btn btn-primary mt-auto w-100"
                          OnClick="btnElegir_Click"
                          CommandArgument='<%# Eval("Id") %>' />
            </div>

          </div>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>

</asp:Content>