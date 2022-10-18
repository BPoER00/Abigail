import Button from "components/Button";
import { SendIcon } from "components/Icons";
import InputControlled from "components/InputControlled";
import LogoWithName from "components/LogoWithName";
import Image from "next/image";
import styles from "../styles/Home.module.css";

const INPUT_DATA = [
  {
    id: "input_data_1",
    label: "Nombre",
    type: "text",
    name: "name",
    placeholder: "Ingrese su nombre",
    maxLength: "100",
    required: true,
  },
  {
    id: "input_data_2",
    label: "Correo",
    type: "email",
    name: "nombre",
    placeholder: "ejemplo@gmail.com",
    maxLength: "100",
    required: true,
  },
];

export default function Home() {
  const handleSubmit = (e) => {
    e.preventDefault();
  };

  return (
    <>
      <nav className={styles.navbar}>
        <div className={styles.container}>
          <LogoWithName color />
          <ul className={styles.nav}>
            <li>
              <a href="#home">Inicio</a>
            </li>
            <li>
              <a href="#about">Acerca de</a>
            </li>
            <li>
              <a href="#quienes-somos">Quienes somos</a>
            </li>
          </ul>
        </div>
      </nav>

      {/* <!-- Showcase --> */}
      <section className={styles.sectionA}>
        <div className={styles.container}>
          <div className={styles.divPresentation}>
            <h1>El sistema de administración del futuro.</h1>
            <p className={styles.description}>
              Organiza y lleva el control de tu condominio o edificio de apartamentos con la mejor herramienta del
              mercado.
            </p>
            <a href="#about" className={styles.btn}>
              Leer más
            </a>
          </div>
          <Image src="/landing-page/home.png" alt="" width={950} height={482} />
        </div>
      </section>

      {/* <!-- Large Text --> */}
      <section id="about" className={styles.sectionB}>
        <div className={styles.overlay}>
          <div className={styles.sectionBInner}>
            <h3>Fácil y manejable</h3>
            <h2>Ahorra un 50% de tiempo</h2>
            <p>
              La administración manual de un condominio o edificio de apartamentos es un trabajo que requiere de mucha
              organización y control. Con un sistema automatizado facilitas la gestión de tu condominio o edificio de
              apartamentos y ahorras un 50% de tiempo.
            </p>
          </div>
        </div>
      </section>

      <section id="quienes-somos" className={styles.container}>
        <div className={styles.videoContainer}>
          <h2 className={styles.titleVideo}>¿Quiénes somos?</h2>
          <video className={styles.video} src="/landing-page/video/Psicoloweb-3.mp4" controls type="video/mp4"></video>
        </div>
      </section>

      {/* <!-- Gallery --> */}
      <section className={styles.sectionC}>
        <div className={styles.gallery}>
          <a href="#">
            <img src="/landing-page/maqueta.jpg" alt="" />
          </a>
          <a href="#">
            <img src="/landing-page/gallery1.jpg" alt="" />
          </a>
          <a href="#">
            <img src="/landing-page/gallery2.jpg" alt="" />
          </a>
          <a href="#">
            <img src="/landing-page/gallery3.jpg" alt="" />
          </a>
          <a href="#">
            <img src="/landing-page/gallery4.jpg" alt="" />
          </a>
          <a href="#">
            <img src="/landing-page/gallery5.jpg" alt="" />
          </a>
        </div>
      </section>

      {/* Formulario de contacto */}
      <section className={styles.container}>
        <div className={styles.formContainer}>
          <form className={styles.form} onSubmit={handleSubmit}>
            <img className={styles.formImage} src="/images/Logo.png" alt="" />
            <h2 className={styles.titleForm}>Formulario de contacto</h2>
            {/* INPUTS: */}
            <div className={styles.containerInputsText}>
              {INPUT_DATA.map(({ id, label, type, name, placeholder, maxLength, required }) => {
                return (
                  <div key={id}>
                    <InputControlled
                      label={label}
                      type={type}
                      name={name}
                      placeholder={placeholder}
                      maxLength={maxLength}
                      required={required}
                    />
                  </div>
                );
              })}
            </div>

            {/* BOTÓN SUBMIT */}
            <Button type="submit">
              Enviar
              <SendIcon />
            </Button>
          </form>
        </div>
      </section>

      {/* <!-- Footer --> */}
      <footer className={styles.sectionFooter}>
        <div className={styles.container}>
          <div>
            <h2>Proyecto Abigail.</h2>
            <a href="http://twitter.com">
              <i class="fab fa-twitter fa-2x"></i>
            </a>
            <a href="http://facebook.com">
              <i class="fab fa-facebook fa-2x"></i>
            </a>
            <a href="http://youtube.com">
              <i class="fab fa-youtube fa-2x"></i>
            </a>
          </div>
          <div>
            <h3>Información de la compañía</h3>
            <ul>
              <li>
                <a href="#">Todos los productos</a>
              </li>
              <li>
                <a href="#">Acerca de nosotros</a>
              </li>
              <li>
                <a href="#">Política de privacidad</a>
              </li>
              <li>
                <a href="#">Términos de servicio</a>
              </li>
            </ul>
          </div>
          <div>
            <h3>Redes sociales</h3>
            <ul>
              <li>
                <a href="#">Facebook</a>
              </li>
              <li>
                <a href="#">Instagram</a>
              </li>
              <li>
                <a href="#">Twitter</a>
              </li>
            </ul>
          </div>
        </div>
      </footer>
    </>
  );
}
