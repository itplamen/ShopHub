import type { Storage } from "redux-persist";

const isServer = typeof window === "undefined";

const noopStorage = {
  getItem: async (_key: string) => null,
  setItem: async (_key: string, _value: string) => {},
  removeItem: async (_key: string) => {},
  getAllKeys: async () => [],
};

const storage: Storage = isServer
  ? (noopStorage as unknown as Storage)
  : ({
      getItem: (key) => Promise.resolve(localStorage.getItem(key)),
      setItem: (key, value) =>
        Promise.resolve(localStorage.setItem(key, value)),
      removeItem: (key) => Promise.resolve(localStorage.removeItem(key)),
      getAllKeys: () => Promise.resolve(Object.keys(localStorage)),
    } as unknown as Storage);

export default storage;
