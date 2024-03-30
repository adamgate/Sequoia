<template>
  <MarkdownEditor :title="exampleTitle" :contents="exampleContent"/>
</template>

<script setup lang="ts">
import MarkdownEditor from './components/markdown-editor.vue'

const exampleTitle = "Example Title";

const exampleContent = 
  `<h3># Hello, world!</h3> 

  <b>**Lorem ipsum dolor**</b> _sit amet_ 

  <ul>
    <li> * Some</li> 
    <li> * Unordered</li> 
    <li> * List </li>
  </ul>

  <ol>
    <li> Some </li> 
    <li> Ordered </li>
    <li> List </li>
  </ol> `;

</script>

<style>

</style>
