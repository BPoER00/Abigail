import Button from "components/Button";
import Input from "components/Input";
import Router from "next/router";

import styles from "./styles.module.css";

export default function FormLogIn() {
  const handleSubmit = (e) => {
    e.preventDefault();

    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);
    const { user, password } = data;

    // TODO: SEND user and password TO BACKEND FOR VALIDATE

    if (user && password) {
      Router.push("/home");
    }
  };

  return (
    <form className={styles.form} onSubmit={handleSubmit}>
      <Input label="Usuario" name="user" placeholder="Ingrese su usuario" required />
      <Input label="Contraseña" name="password" type="password" placeholder="Ingrese su contraseña" required />
      <Button type="submit">Entrar</Button>
    </form>
  );
}
