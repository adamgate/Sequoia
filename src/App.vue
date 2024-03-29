<template>
  <h1>Test</h1>
  <MarkdownEditor :title="exampleTitle" :contents="exampleContent"/>
</template>

<script setup lang="ts">
import MarkdownEditor from './components/markdown-editor.vue'

const exampleTitle = "Example"

const exampleContent = 
  `# Hello, world! 

  **Lorem ipsum dolor** _sit amet_ 

  * Some 
  * Unordered 
  * List 

  1. Some 
  1. Ordered 
  1. List `

</script>

<style>

</style>
