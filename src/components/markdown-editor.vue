<template>
  <h1 id="editor-title" @input="onTitleInput" v-html="documentTitle" contenteditable="true" />
  <div id="editor">
    <div id="toolbar" class="flex flex-wrap">
      <button
        @click="applyBold"
        class="toolbar-button"
        data-toggle="tooltip"
        data-placement="top"
        title="Bold"
      >
        <i class="bi bi-type-bold" />
      </button>
      <button
        @click="applyItalic"
        class="toolbar-button"
        data-toggle="tooltip"
        data-placement="top"
        title="Italic"
      >
        <i class="bi bi-type-italic" />
      </button>

      <div class="dropdown">
        <button
          class="toolbar-button"
          data-toggle="tooltip"
          data-placement="top"
          title="Headings"
        >
          <i class="bi bi-card-heading"></i>
        </button>
        <div class="dropdown-content">
          <button
            @click="applyHeading1"
            class="toolbar-button"
            data-toggle="tooltip"
            data-placement="top"
            title="Heading 1"
          >
            <i class="bi bi-type-h1" />
          </button>
          <button
            @click="applyHeading2"
            class="toolbar-button"
            data-toggle="tooltip"
            data-placement="top"
            title="Heading 2"
          >
            <i class="bi bi-type-h2" />
          </button>
          <button
            @click="applyHeading3"
            class="toolbar-button"
            data-toggle="tooltip"
            data-placement="top"
            title="Heading 3"
          >
            <i class="bi bi-type-h3" />
          </button>
          <button
            @click="applyHeading4"
            class="toolbar-button"
            data-toggle="tooltip"
            data-placement="top"
            title="Heading 4"
          >
            <i class="bi bi-type-h4" />
          </button>
          <button
            @click="applyHeading5"
            class="toolbar-button"
            data-toggle="tooltip"
            data-placement="top"
            title="Heading 5"
          >
            <i class="bi bi-type-h5" />
          </button>
          <button
            @click="applyHeading6"
            class="toolbar-button"
            data-toggle="tooltip"
            data-placement="top"
            title="Heading 6"
          >
            <i class="bi bi-type-h6" />
          </button>
        </div>
      </div>

      <button
        @click="applyUnorderedList"
        class="toolbar-button"
        data-toggle="tooltip"
        data-placement="top"
        title="Unordered List"
      >
        <i class="bi bi-list-ul" />
      </button>
      <button
        @click="applyOrderedList"
        class="toolbar-button"
        data-toggle="tooltip"
        data-placement="top"
        title="Ordered List"
      >
        <i class="bi bi-list-ol" />
      </button>
      <button
        @click="applyChecklist"
        class="toolbar-button"
        data-toggle="tooltip"
        data-placement="top"
        title="Checklist"
      >
        <i class="bi bi-list-task" />
      </button>
      <button
        @click="insertTable"
        class="toolbar-button"
        data-toggle="tooltip"
        data-placement="top"
        title="Insert Table"
      >
        <i class="bi bi-table" />
      </button>
      <button
        @click="insertHorizontalRule"
        class="toolbar-button"
        data-toggle="tooltip"
        data-placement="top"
        title="Insert Horizontal Rule"
      >
        <i class="bi bi-hr" />
      </button>
      <button
        @click="insertImage"
        class="toolbar-button"
        data-toggle="tooltip"
        data-placement="top"
        title="Insert Image"
      >
        <i class="bi bi-card-image" />
      </button>
      <button
        @click=""
        class="toolbar-button"
        data-toggle="tooltip"
        data-placement="top"
        title="Insert Link"
      >
        <i class="bi bi-link" />
      </button>
      <button
        @click="undo"
        class="toolbar-button"
        data-toggle="tooltip"
        data-placement="top"
        title="Undo"
      >
        <i class="bi bi-arrow-counterclockwise" />
      </button>
      <button
        @click="redo"
        class="toolbar-button"
        data-toggle="tooltip"
        data-placement="top"
        title="Redo"
      >
        <i class="bi bi-arrow-clockwise" />
      </button>
      <div
        id="editor-text"
        @input="onDocumentInput($event)"
        v-html="markdown.render(documentContents)"
        contenteditable="true"
        class="border rounded editor-output markdown-body"
      />
    </div>
  </div>
</template>

<script lang="ts">
import MarkdownIt from "markdown-it";
import "bootstrap-icons/font/bootstrap-icons.css";

export default {
  name: "MarkdownEditor",
  props: {
    contents: {
      type: String,
      required: true,
    },
    title: {
      type: String,
      required: true,
    },
  },
  data() {
    return {
      documentContents: this.contents || "<p><br></p>",
      documentTitle: this.title || "Untitled",
      markdown: new MarkdownIt()
    };
  },
  mounted() {
    document.execCommand("defaultParagraphSeparator", false, "p");
  },
  methods: {
    onTitleInput(event: Event) {
      // this.$emit("input", event.target?['documentTitle']);
    },
    onDocumentInput(event: Event) {
      // this.$emit("input", event.target.value);
    },

    // Note: execCommand is deprecated, but research indicates that there isn't anything adequate to replace it.
    // Several sources suggested continuing using it because of that. It would be more of an issue if the app wasn't using electron.
    applyBold() {
      if (!this.isSelectionInEditorText())
        return;

      document.execCommand("bold");
    },
    applyItalic() {
      if (!this.isSelectionInEditorText())
        return;

      document.execCommand("italic");
    },
    applyHeading1() {
      if (!this.isSelectionInEditorText())
        return;

      document.execCommand("formatBlock", false, "<h1>");
    },
    applyHeading2() {
      if (!this.isSelectionInEditorText())
        return;

      document.execCommand("formatBlock", false, "<h2>");
    },
    applyHeading3() {
      if (!this.isSelectionInEditorText())
        return;

      document.execCommand("formatBlock", false, "<h3>");
    },
    applyHeading4() {
      if (!this.isSelectionInEditorText())
        return;

      document.execCommand("formatBlock", false, "<h4>");
    },
    applyHeading5() {
      if (!this.isSelectionInEditorText())
        return;

      document.execCommand("formatBlock", false, "<h5>");
    },
    applyHeading6() {
      if (!this.isSelectionInEditorText())
        return;

      document.execCommand("formatBlock", false, "<h6>");
    },
    applyUnorderedList() {
      if (!this.isSelectionInEditorText())
        return;

      document.execCommand("insertUnorderedList");
    },
    applyOrderedList() {
      if (!this.isSelectionInEditorText())
        return;

      document.execCommand("insertOrderedList");
    },
    applyChecklist() {
      if (!this.isSelectionInEditorText())
        return;

      // TODO - implement checklist behavior (will need markdown-it extra module + custom html code to add the " - [ ] "")
    },
    insertTable() {
      if (!this.isSelectionInEditorText())
        return;

      // TODO - implement table behavior (will need markdown-it extra module + custom html code to add the " - [ ] "")
    },
    insertHorizontalRule() {
      if (!this.isSelectionInEditorText())
        return;

      document.execCommand("insertHorizontalRule");
    },
    insertHyperlink() {
      if (!this.isSelectionInEditorText())
        return;

      document.execCommand("createLink", false, "");
    },
    insertImage() {
      if (!this.isSelectionInEditorText())
        return;
      
      document.execCommand("insertImage");
    },
    undo() {
      if (!this.isSelectionInEditorText())
        return;

      document.execCommand("undo");
    },
    redo() {
      if (!this.isSelectionInEditorText())
        return;

      document.execCommand("redo");
    },

    // Only allow the toolbar buttons to work on the editor text box
    isSelectionInEditorText() : boolean {
      return window.getSelection()?.focusNode?.parentElement?.parentElement?.id === "editor-text";
    }
  },
};
</script>

<!-- <style src="node_modules\github-markdown-css\github-markdown-light.css"> -->
<style>
.toolbar-button {
  font-size: 1.2em;
  border: .13rem solid gray;
  border-radius: 5px;
  padding: 5 4 5 4px;
  margin: 2px;
  background-color: white;
  color: black;
  -webkit-text-stroke: .3px black;
}

.toolbar-button:hover {
  background-color: black;
  border-color: black;
  color: white;
  -webkit-text-stroke: white;
}

.dropdown {
  position: relative;
  display: inline-block;
}

/* Dropdown Content (Hidden by Default) */
.dropdown-content {
  display: none;
  position: absolute;
  background-color: white;
  min-width: 230px;
  /* box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2); */
  z-index: 1;
}

/* Show the dropdown menu on hover */
.dropdown:hover .dropdown-content {
  display: block;
}

.editor-output {
  height: 100%;
  display: block;
}
</style>
