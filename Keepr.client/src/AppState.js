import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  account: {},
  profile: {},
  /** @type {import('.model/Vault.js').Vault[]} */
  vaults: [],
  vault: null,
  /** @type {import('.model/Keep.js').Keep[]} */
  keeps: [],
  keep: null
})
