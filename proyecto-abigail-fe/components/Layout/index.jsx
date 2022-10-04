import { CashIcon, DownArrowIcon, HomeIcon, ObjectsIcon, ReportsIcon, SettingsIcon } from "components/Icons";
import Logo from "components/Logo";
import Image from "next/image";
import Link from "next/link";
import styles from "./styles.module.css";

const OPTIONS = [
  {
    id: 1,
    root: "/home",
    icon: () => <HomeIcon />,
    title: "Home",
    path: "/home",
  },
  {
    id: 2,
    root: "/cuentas-por-cobrar",
    icon: () => <CashIcon />,
    title: "Cuentas por cobrar",
    path: "/cuentas-por-cobrar",
  },
  {
    id: 3,
    root: "/reportes",
    icon: () => <ReportsIcon />,
    rightIcon: () => <DownArrowIcon />,
    title: "Reportes",
    subModules: [
      {
        id: "r1",
        title: "Control de espacios públicos",
        path: "/reportes/control-espacios-publicos",
      },
      {
        id: "r2",
        title: "Control físico de propiedades",
        path: "/reportes/control-fisico-propiedades",
      },
      {
        id: "r3",
        title: "Estado de morosidad y cuentas por cobrar",
        path: "/reportes/estado-morosidad-cuentas-por-cobrar",
      },
      {
        id: "r4",
        title: "Estado de quejas",
        path: "/reportes/estado-quejas",
      },
      {
        id: "r5",
        title: "Reportes de ingresos y egresos al condominio",
        path: "/reportes/ingresos-egresos-condominio",
      },
    ],
  },
  {
    id: 4,
    root: "/objetos",
    icon: () => <ObjectsIcon />,
    rightIcon: () => <DownArrowIcon />,
    title: "Objetos",
    subModules: [
      {
        id: "o1",
        title: "Crear personas",
        path: "/objetos/personas",
      },
      {
        id: "o2",
        title: "Propiedades",
        path: "/objetos/propiedades",
      },
    ],
  },
];

export default function Layout({ children, currentPage }) {
  return (
    <div className={styles.container}>
      <aside className={styles.aside}>
        <header className={styles.headerAside}>
          <Link href={"/home"}>
            <a className={styles.logoLarge}>
              <Logo width="56" height="42" />
              <span className={styles.label}>Abigail</span>
            </a>
          </Link>
          <button className={styles.bthHidden}>
            <Image src={"/icons/left-arrow.svg"} width={24} height={24} alt="Logo Abigail" />
          </button>
        </header>
        <nav className={styles.nav}>
          <ul className={styles.ul}>
            {OPTIONS.map(({ id, icon, rightIcon, title, path = "", subModules = [], root }) => {
              return (
                <li className={`${styles.item} ${root === currentPage && styles.currentItem}`} key={id}>
                  {subModules.length > 0 ? (
                    <button className={styles.dropDown}>
                      {typeof icon === "function" && icon()}
                      <span>{title}</span>
                      {typeof icon === "function" && rightIcon()}
                    </button>
                  ) : (
                    <Link href={path}>
                      <a className={styles.element}>
                        {typeof icon === "function" && icon()}
                        <span className={styles.link}>{title}</span>
                      </a>
                    </Link>
                  )}
                </li>
              );
            })}
          </ul>
        </nav>
        <Link href={"/config"}>
          <a className={styles.config}>
            <SettingsIcon />
            <span>Configuraciones</span>
          </a>
        </Link>
      </aside>

      <main className={styles.mainContainer}>
        <header className={styles.header}>
          Lorem ipsum dolor sit amet consectetur adipisicing elit. Enim repudiandae maxime labore quo, velit, ipsa
          laborum eveniet, numquam reprehenderit assumenda suscipit ullam hic earum accusamus voluptatibus consequatur
          omnis cupiditate illum.
        </header>
        <section className={styles.content}>{children}</section>
      </main>
    </div>
  );
}
