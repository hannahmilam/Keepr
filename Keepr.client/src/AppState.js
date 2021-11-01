import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  account: {},
   /** @type {import('.model/Profile.js').Profile[]} */
  profile: {},
  currentProfile: {},
  /** @type {import('.model/Vault.js').Vault[]} */
  vaults: [],
  vault: null,
  /** @type {import('.model/Keep.js').Keep[]} */
  keeps: [],
  keep: null,
   /** @type {import('.model/VaultKeep.js').VaultKeep[]} */
  vaultKeeps: [],
  vaultKeep: null
})
