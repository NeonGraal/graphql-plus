import peg from "./peg.js";

export default {
  configureHljs: function (hljs) {
    hljs.registerLanguage("peg", peg);
  },
};
