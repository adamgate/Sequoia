import { createApp } from 'vue'
import App from './App.vue'
import * as bootstrap from 'bootstrap'

import './scss/styles.scss'
import './style.css'

import './demos/ipc'
// If you want use Node.js, the`nodeIntegration` needs to be enabled in the Main process.
// import './demos/node'

createApp(App)
  .mount('#app')
  .$nextTick(() => {
    postMessage({ payload: 'removeLoading' }, '*')
  })
