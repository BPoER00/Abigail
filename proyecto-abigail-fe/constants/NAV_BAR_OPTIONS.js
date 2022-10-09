import { CashIcon, DownArrowIcon, HomeIcon, ObjectsIcon, ReportsIcon } from "components/Icons";

export const NAV_BAR_OPTIONS = [
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
        title: "Registrar personas",
        path: "/objetos/personas",
      },
      {
        id: "o2",
        title: "Registrar Propiedades",
        path: "/objetos/propiedades",
      },
    ],
  },
];
