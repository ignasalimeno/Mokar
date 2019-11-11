<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Index.aspx.vb" Inherits="GUI.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="intro" class="clearfix">

        <div class="container d-flex h-100">
            <div class="row">
                <div class="col-8">
                    <div class="row justify-content-center align-self-center">

                        <div class="col-md-6 intro-info order-md-first order-last">
                            <h2>Potenciando tus objetivos<br>
                                y tus <span>Resultados!</span></h2>
                        </div>

                        <div class="col-md-6 intro-img order-md-last order-first">
                            <img src="img/intro-img.svg" alt="" class="img-fluid">
                        </div>
                    </div>
                </div>
                <div class="col-4" id="panelEncuesta" runat="server">
                  <div class="card-body">
                        <div class="card card-body">
                       <h3 id="Pregunta" runat="server"></h3>

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                            <asp:HiddenField ID="idPregunta" runat="server" />
                            <asp:RadioButtonList runat="server" ID="rbPreguntas" AutoPostBack="true">
                            </asp:RadioButtonList>
                                    
                            <asp:Chart ID="chReportes" runat="server" CssClass="chart" Visible="false" BackColor="LightGray" Width="280px">
                                <Series>
                                    <asp:Series Name="Series1"></asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1" AlignmentOrientation="Horizontal" Area3DStyle-Enable3D="true"
                                        Area3DStyle-WallWidth="2" Area3DStyle-Rotation="20"
                                        Area3DStyle-LightStyle="Simplistic" Area3DStyle-Inclination="40"
                                        BorderColor="White" ShadowColor="#CCCCCC">
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                                    </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                            <asp:Button ID="btnVotar" Text="Votar" CssClass="btn btn-primary" runat="server" />
                        </div>

                  </div>
                </div>
            </div>

        </div>

  </section><!-- #intro -->

    <!--==========================
      About Us Section
    ============================-->
    <section id="about">

      <div class="container">
        <div class="row">

          <div class="col-lg-5 col-md-6">
            <div class="about-img">
              <img src="img/about-img.jpg" alt="">
            </div>
          </div>

          <div class="col-lg-7 col-md-6">
            <div class="about-content">
              <h2>¿Quienes somos?</h2>
              <h3>Mokar, una empresa dedicada a ayudarte a alcanzar tus objetivos.</h3>
              <p>Somos un grupo de especialistas, focalizados en brindar la mejor esperiencia al cliente .</p>
              <p>Desde hace más de 5 años nos capacitamos constantemente en aprender y transmitir conocimientos en metodología de gestión por objetivos. Haciendo crecer a nuestros clientes a la par neustra, buscamos conseguir los mejores resultados.</p>
              <ul>
                <li><i class="ion-android-checkmark-circle"></i> Experiencia del cliente 100 % alcanzada.</li>
                <li><i class="ion-android-checkmark-circle"></i> Profesionales con capacidades técnicas adecuadas para esta metodología.</li>
                <li><i class="ion-android-checkmark-circle"></i> Emprendedores con cabeza y corazón empeñados en cumplir y potenciar resultados.</li>
              </ul>
            </div>
          </div>
        </div>
      </div>

    </section><!-- #about -->

    <!--==========================
      Why Us Section
    ============================-->
    <section id="why-us" class="wow fadeIn">
      <div class="container-fluid">
        
        <header class="section-header">
          <h3>¿Por que elegirnos?</h3>
          <p>Somos la primer empresa argentina especializada en metodología OKR.</p>
        </header>

        <div class="row">

          <div class="col-lg-6">
            <div class="why-us-img">
              <img src="img/equipo1.jpg" alt="" class="img-fluid">
            </div>
          </div>

          <div class="col-lg-6">
            <div class="why-us-content">
              <p>Trabajamos folizados y especializandonos en cada uno de nuestro clientes, logrando así una confianza y una sinergia total con cada uno de ellos.</p>
              <p>
                Colaborando y poniendonos en lugar de nuetro clientes, hacemos que todo funcione de manera más sencilla y fácil.

                Entendemos tus problemas y las necesidades del contexto como ninguna otra empresa puede hacerlo.
              </p>

              <div class="features wow bounceInUp clearfix">
                <i class="fa fa-diamond" style="color: #f058dc;"></i>
                <h4>Experiencia </h4>
                <p>Nuestro principal interés es lograr una experiencia increible en nuestros clientes.</p>
              </div>

              <div class="features wow bounceInUp clearfix">
                <i class="fa fa-object-group" style="color: #ffb774;"></i>
                <h4>Precios</h4>
                <p>Contamos con los mejores precios del mercado. Precios bajos y en pesos hace que no puedan competir con nosotros.</p>
              </div>
              
              <div class="features wow bounceInUp clearfix">
                <i class="fa fa-language" style="color: #589af1;"></i>
                <h4>Personal capacitado</h4>
                <p>Nuestro personal está capacitado y forzjado con los conocimientos más sólidos del mercado.</p>
              </div>
              
            </div>

          </div>

        </div>

      </div>

      <div class="container">
        <div class="row counters">

          <div class="col-lg-3 col-6 text-center">
            <span data-toggle="counter-up">78</span>
            <p>Clientes</p>
          </div>

          <div class="col-lg-3 col-6 text-center">
            <span data-toggle="counter-up">221</span>
            <p>Proyectos</p>
          </div>

          <div class="col-lg-3 col-6 text-center">
            <span data-toggle="counter-up">1,364</span>
            <p>Horas de soporte</p>
          </div>

          <div class="col-lg-3 col-6 text-center">
            <span data-toggle="counter-up">4</span>
            <p>Planes diferentes</p>
          </div>
  
        </div>

      </div>
    </section>

    <!--==========================
      Clients Section
    ============================-->
    <section id="testimonials">
      <div class="container">

        <header class="section-header">
          <h3>Testimonios</h3>
        </header>

        <div class="row justify-content-center">
          <div class="col-lg-8">

            <div class="owl-carousel testimonials-carousel wow fadeInUp">
    
              <div class="testimonial-item">
                <img src="img/testimonial-1.jpg" class="testimonial-img" alt="">
                <h3>Lucas Pratto</h3>
                <p>
                  Con Mokar pudimos alcanzar nuestros objetivos de forma más clara y concreta. Una gran herramienta que nos ayudó en nuestro management.
                </p>
              </div>
    
              <div class="testimonial-item">
                <img src="img/testimonial-2.jpg" class="testimonial-img" alt="">
                <h3>Marcelo Gallardo</h3>
                <p>
                  Agradezco a Mokar y a todo su equipo por habernos ayudado en la implementación de la metodología de forma fácil.
                </p>
              </div>
    
              <div class="testimonial-item">
                <img src="img/testimonial-3.jpg" class="testimonial-img" alt="">
                <h3>Juan Fernando Quintero</h3>
                <p>
                  Estabamos aprendiendo de OKR y nos encontramos con una empresa dispuesta a ayudar, capacitar y ser la única que pudo ayudarnos.
                </p>
              </div>
    
              <div class="testimonial-item">
                <img src="img/testimonial-4.jpg" class="testimonial-img" alt="">
                <h3>Gonzalo Martinez</h3>
                <p>
                   Con Mokar pudimos alcanzar nuestros objetivos de forma más clara y concreta. Una gran herramienta que nos ayudó en nuestro management.
                </p>
              </div>

            </div>

          </div>
        </div>


      </div>
    </section><!-- #testimonials -->


    <!--==========================
      Services Section
    ============================-->
    <section id="services" class="section-bg">
      <div class="container">

        <header class="section-header">
          <h3>Servicios</h3>
          <p>Contamos con diferentes tipos de planes que puodes contratar y que se van a ajustar perfecto a tu medida. Para conocer más de ellos podes hacer <a href="Servicios.aspx">click aquí.</a></p>
        </header>

        <div class="row">

          <div class="col-md-6 col-lg-4 wow bounceInUp" data-wow-duration="1.4s">
            <div class="box">
              <div class="icon" style="background: #fceef3;"><i class="ion-ios-analytics-outline" style="color: #ff689b;"></i></div>
              <h4 class="title"><a href="">Atención personalizada</a></h4>
              <p class="description">Nos focalizamos en una atención 100% personalizada para poder acompañarte y ser parte de tu cambio transformacional</p>
            </div>
          </div>
          <div class="col-md-6 col-lg-4 wow bounceInUp" data-wow-duration="1.4s">
            <div class="box">
              <div class="icon" style="background: #fff0da;"><i class="ion-ios-bookmarks-outline" style="color: #e98e06;"></i></div>
              <h4 class="title"><a href="">Certificados en OKR</a></h4>
              <p class="description">Contamos con las capacidades y el profesionalismo que esta metodología requiere</p>
            </div>
          </div>

          <div class="col-md-6 col-lg-4 wow bounceInUp" data-wow-delay="0.1s" data-wow-duration="1.4s">
            <div class="box">
              <div class="icon" style="background: #e6fdfc;"><i class="ion-ios-paper-outline" style="color: #3fcdc7;"></i></div>
              <h4 class="title"><a href="">Material de interés</a></h4>
              <p class="description">Disponibilizamos de material de estudio para que puedas leer y aprender más acerca de OKR</p>
            </div>
          </div>
          <div class="col-md-6 col-lg-4 wow bounceInUp" data-wow-delay="0.1s" data-wow-duration="1.4s">
            <div class="box">
              <div class="icon" style="background: #eafde7;"><i class="ion-ios-speedometer-outline" style="color:#41cf2e;"></i></div>
              <h4 class="title"><a href="">Reporting</a></h4>
              <p class="description">Con nuestra plataforma, vas a poder generar todo tipo de reportes que te van a ayudar a cumplir con tus objetivos</p>
            </div>
          </div>

          <div class="col-md-6 col-lg-4 wow bounceInUp" data-wow-delay="0.2s" data-wow-duration="1.4s">
            <div class="box">
              <div class="icon" style="background: #e1eeff;"><i class="ion-ios-world-outline" style="color: #2282ff;"></i></div>
              <h4 class="title"><a href="">Multilenguaje</a></h4>
              <p class="description">Contamos con la primer y única plataforma de OKR en Español, que a su vez se puede traducir en cualquier idioma</p>
            </div>
          </div>
          <div class="col-md-6 col-lg-4 wow bounceInUp" data-wow-delay="0.2s" data-wow-duration="1.4s">
            <div class="box">
              <div class="icon" style="background: #ecebff;"><i class="ion-ios-clock-outline" style="color: #8660fe;"></i></div>
              <h4 class="title"><a href="">A Tiempo</a></h4>
              <p class="description">Nuestro enfoque orientado a cliente, hace que nunca demoremos en poder asistirte y capacitarte</p>
            </div>
          </div>

        </div>

          </div>

<div class="container">
          <br />
          <h4 class="text-center">Ranking de productos mas votados</h4>
    
                    <div class="col-12" style="align-items :center"">
                        <div class="row rating-desc">
                              <div class="col-xs-3 col-md-9 text-right">
                                <span class="glyphicon glyphicon-star"><p>Blue</p></span>
                            </div>
                            <div class="col-xs-8 col-md-9">
                                <div class="progress progress-striped">
                                    <div runat="server" class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="20"
                                        aria-valuemin="0" aria-valuemax="100" style="width:76%" >
                                        <span class="sr-only"></span> 
                                    </div>
                                </div>
                            </div>

                              <div class="col-xs-3 col-md-9 text-right">
                                <span class="glyphicon glyphicon-star"><p>Black</p></span>
                            </div>
                            <div class="col-xs-8 col-md-9">
                                <div class="progress progress-striped">
                                    <div runat="server" class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="20"
                                        aria-valuemin="0" aria-valuemax="100" style="width:58%" >
                                        <span class="sr-only"></span> 
                                    </div>
                                </div>
                            </div>

                              <div class="col-xs-3 col-md-9 text-right">
                                <span class="glyphicon glyphicon-star"><p> Bronce</p></span>
                            </div>
                            <div class="col-xs-8 col-md-9">
                                <div class="progress progress-striped">
                                    <div runat="server" class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="20"
                                        aria-valuemin="0" aria-valuemax="100" style="width:25%" >
                                        <span class="sr-only"></span> 
                                    </div>
                                </div>
                            </div>

                              <div class="col-xs-3 col-md-9 text-right">
                                <span class="glyphicon glyphicon-star"><p> Platinum </p></span>
                            </div>
                            <div class="col-xs-8 col-md-9">
                                <div class="progress progress-striped">
                                    <div runat="server" class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="20"
                                        aria-valuemin="0" aria-valuemax="100" style="width:17%" >
                                        <span class="sr-only"></span> 
                                    </div>
                                </div>
                            </div>

                              <div class="col-xs-3 col-md-9 text-right">
                                <span class="glyphicon glyphicon-star"><p>Gold</p></span>
                            </div>
                            <div class="col-xs-8 col-md-9">
                                <div class="progress progress-striped">
                                    <div runat="server" class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="20"
                                        aria-valuemin="0" aria-valuemax="100" style="width:12%" >
                                        <span class="sr-only"></span> 
                                    </div>
                                </div>
                            </div>

                            <!-- end 1 -->
                        </div>
                        <!-- end row -->
                    </div>
                
 </div>
       </section><!-- #services -->

     

   
      

    <!--==========================
      Team Section
    ============================-->
    <section id="team" class="section-bg">
      <div class="container">
        <div class="section-header">
          <h3>Equipo</h3>
          <p>Conocé a los quienes van a hacer que puedas alcanzar con todos tus objetivos!</p>
        </div>

        <div class="row">

          <div class="col-lg-3 col-md-6 wow fadeInUp">
            <div class="member">
              <img src="img/yo.jpg" class="img-fluid" alt="">
              <div class="member-info">
                <div class="member-info-content">
                  <h4>Ignacio Salimeno</h4>
                  <span>CEO y Fundador</span>
                  <div class="social">
                  </div>
                </div>
              </div>
            </div>
          </div>

          <div class="col-lg-3 col-md-6 wow fadeInUp" data-wow-delay="0.1s">
            <div class="member">
              <img src="img/lucha.jpg" class="img-fluid" alt="">
              <div class="member-info">
                <div class="member-info-content">
                  <h4>Luciana Escalada</h4>
                  <span>Lider de Exp al Cliente</span>
                  <div class="social">
                  </div>
                </div>
              </div>
            </div>
          </div>

          <div class="col-lg-3 col-md-6 wow fadeInUp" data-wow-delay="0.2s">
            <div class="member">
              <img src="img/genti.jpg" class="img-fluid" alt="">
              <div class="member-info">
                <div class="member-info-content">
                  <h4>Cristian Gentile</h4>
                  <span>Líder Técnico</span>
                </div>
              </div>
            </div>
          </div>

            <div class="col-lg-3 col-md-6 wow fadeInUp" data-wow-delay="0.3s">
            <div class="member">
              <img src="img/mocca.jpg" class="img-fluid" alt="">
              <div class="member-info">
                <div class="member-info-content">
                  <h4>Rodrigo Mocca</h4>
                  <span>Especialista de OKR</span>
                </div>
              </div>
            </div>
          </div>


        </div>

      </div>
    </section><!-- #team -->

    <!--==========================
      Clients Section
    ============================-->

    <%--<section id="clients" class="wow fadeInUp">
      <div class="container">

        <header class="section-header">
          <h3>Our Clients</h3>
        </header>

        <div class="owl-carousel clients-carousel">
          <img src="img/clients/client-1.png" alt="">
          <img src="img/clients/client-2.png" alt="">
          <img src="img/clients/client-3.png" alt="">
          <img src="img/clients/client-4.png" alt="">
          <img src="img/clients/client-5.png" alt="">
          <img src="img/clients/client-6.png" alt="">
          <img src="img/clients/client-7.png" alt="">
          <img src="img/clients/client-8.png" alt="">
        </div>

      </div>
    </section><!-- #clients -->--%>


 
    <!--==========================
      Frequently Asked Questions Section
    ============================-->
    <section id="faq">
      <div class="container">
        <header class="section-header">
          <h3>Preguntas frecuentes</h3>
          <p>Antes de contactar a nuestro equipo, te acercamos algunas dudas comunes</p>
        </header>

        <ul id="faq-list" class="wow fadeInUp">
          <li>
            <a data-toggle="collapse" class="collapsed" href="#faq1">¿Que es OKR? <i class="ion-android-remove"></i></a>
            <div id="faq1" class="collapse" data-parent="#faq-list">
              <p>
                OKR es una metodología de gestión y alineación estratégica de objetivos.
              </p>
            </div>
          </li>

          <li>
            <a data-toggle="collapse" href="#faq2" class="collapsed">¿Que necesito para aplicar OKR? <i class="ion-android-remove"></i></a>
            <div id="faq2" class="collapse" data-parent="#faq-list">
              <p>
                Para lograrlo necesitas tener una cultura de trabajo por objetivo, sino la tenés, nosotros te ayudamos a lograrlo!
              </p>
            </div>
          </li>

          <li>
            <a data-toggle="collapse" href="#faq3" class="collapsed">¿Puedo aplicar OKR en cualquier empresa? <i class="ion-android-remove"></i></a>
            <div id="faq3" class="collapse" data-parent="#faq-list">
              <p>
                Si! Está orientado al mundo del desarrollo de software, pero se puede aplicar en cualquier empresa sin ningún problema!
              </p>
            </div>
          </li>

          <li>
            <a data-toggle="collapse" href="#faq4" class="collapsed">¿Cuales son los pasos a seguir? <i class="ion-android-remove"></i></a>
            <div id="faq4" class="collapse" data-parent="#faq-list">
              <p>
                OKR intenta dividir tus objetivos de dos formas: declarar un Objetivo aspiracional y enunciar los Resultados Claves que nos llevan a lograrlo.
              </p>
            </div>
          </li>

          <li>
            <a data-toggle="collapse" href="#faq5" class="collapsed">¿Que significa OKR? <i class="ion-android-remove"></i></a>
            <div id="faq5" class="collapse" data-parent="#faq-list">
              <p>
                OKR es una sigla de "Objectives and Key Results" y se traduce cómo "Objetivos y Resultados Claves"
              </p>
            </div>
          </li>

          <li>
            <a data-toggle="collapse" href="#faq6" class="collapsed">¿Mokar tiene las capacidades suficentes para ayudarme? <i class="ion-android-remove"></i></a>
            <div id="faq6" class="collapse" data-parent="#faq-list">
              <p>
                Somos la única empresa argentina que puede ayudarte con OKR. Vamos a poder acercanos y capacitarte en tu lugar de trabajo!
              </p>
            </div>
          </li>

        </ul>

      </div>
    </section><!-- #faq -->


    
</asp:Content>
