<template>
  <div class="flex flex-wrap">
    <button @click="applyBold" class="button">
      <i class="bi bi-type-bold" />
    </button>
    <button @click="applyBold" class="button">
      <i class="bi bi-type-italic" />
    </button>
    <button @click="applyBold" class="button">
      <i class="bi bi-type-h1" />
    </button>
    <button @click="applyBold" class="button">
      <i class="bi bi-type-h2" />
    </button>
    <button @click="applyBold" class="button">
      <i class="bi bi-type-h3" />
    </button>
    <button @click="applyBold" class="button">
      <i class="bi bi-type-h4" />
    </button>
    <button @click="applyBold" class="button">
      <i class="bi bi-type-h5" />
    </button>
    <button @click="applyBold" class="button">
      <i class="bi bi-type-h6" />
    </button>
    <button @click="applyBold" class="button">
      <i class="bi bi-list-ol" />
    </button>
    <button @click="applyBold" class="button">
      <i class="bi bi-list-ul" />
    </button>
    <button @click="applyBold" class="button">
      <i class="bi bi-check2-square" />
    </button>
    <button @click="applyBold" class="button">
      <i class="bi bi-arrow-counterclockwise" />
    </button>
    <button @click="applyBold" class="button">
      <i class="bi bi-arrow-clockwise" />
    </button>
    <div
      @input="onInput"
      v-html="innerValue"
      contentedittable="true"
      class="border border-primary rounded p-2"
      style="resize:none"
    />
  </div>
</template>

<script lang="ts">
import 'bootstrap-icons/font/bootstrap-icons.css'

export default {
  name: "MarkdownEditor",

  props: ["value"],

  data() {
    return {
      innerValue: this.value,
    };
  },

  methods: {
    onInput(event) {
      this.$emit("input", event.target.innerHTML);
    },
    applyBold() {
    }
  },
};
</script>

<style>
  .button {
    @apply border-2;
    @apply border-gray-300;
    @apply rounded-lg;
    @apply px-3 py-1;
    @apply mb-3 mr-3;
  }

  .button:hover {
    @apply border-green-300;
  }
</style>
