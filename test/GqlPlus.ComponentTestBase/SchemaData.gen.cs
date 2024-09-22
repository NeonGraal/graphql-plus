// Generated from .\test\GqlPlus.ComponentTestBase\Samples\Schema
// Collected from 9328e1e  (HEAD -> samples, origin/samples) 2024-09-22 Split schema errors into parse and verify


namespace GqlPlus;

public class SchemaInvalidGlobalsData
  : TheoryData<string>
{
  public static readonly string[] Keys = [
    "bad-parse",
    "category-diff-mod",
    "category-dup-alias",
    "category-duplicate",
    "category-output-generic",
    "category-output-mod-param",
    "category-output-undef",
    "category-output-wrong",
    "directive-diff-option",
    "directive-diff-param",
    "directive-no-param",
    "directive-param-mod-param",
    "option-diff-name",
  ];

  public SchemaInvalidGlobalsData()
  {
    foreach (string key in Keys) {
      Add(key);
    }
  }
}

public class SchemaInvalidObjectsData
  : TheoryData<string>
{
  public static readonly string[] Keys = [
    "alt-diff-mod",
    "alt-mod-undef",
    "alt-mod-undef-param",
    "alt-mod-wrong",
    "alt-more",
    "alt-recurse",
    "alt-self",
    "alt-simple-param",
    "dual-alt-input",
    "dual-alt-output",
    "dual-alt-param-input",
    "dual-alt-param-output",
    "dual-field-input",
    "dual-field-output",
    "dual-field-param-input",
    "dual-field-param-output",
    "dual-parent-input",
    "dual-parent-output",
    "dual-parent-param-input",
    "dual-parent-param-output",
    "field-alias",
    "field-diff-mod",
    "field-diff-type",
    "field-mod-undef",
    "field-mod-undef-param",
    "field-mod-wrong",
    "field-simple-param",
    "generic-alt-undef",
    "generic-arg-less",
    "generic-arg-more",
    "generic-arg-undef",
    "generic-field-undef",
    "generic-param-undef",
    "generic-parent-less",
    "generic-parent-more",
    "generic-parent-undef",
    "generic-unused",
    "input-alt-output",
    "input-field-null",
    "input-field-output",
    "input-parent-output",
    "output-alt-input",
    "output-enum-bad",
    "output-enum-diff",
    "output-enumValue-bad",
    "output-enumValue-wrong",
    "output-field-input",
    "output-generic-enum-bad",
    "output-generic-enum-wrong",
    "output-param-diff",
    "output-param-mod-undef",
    "output-param-mod-undef-param",
    "output-param-mod-wrong",
    "output-param-undef",
    "output-parent-input",
    "parent-alt-mod",
    "parent-alt-more",
    "parent-alt-recurse",
    "parent-alt-self",
    "parent-alt-self-more",
    "parent-alt-self-recurse",
    "parent-field-alias",
    "parent-field-alias-more",
    "parent-field-alias-recurse",
    "parent-field-mod",
    "parent-field-mod-more",
    "parent-field-mod-recurse",
    "parent-more",
    "parent-recurse",
    "parent-self",
    "parent-self-alt",
    "parent-self-alt-more",
    "parent-self-alt-recurse",
    "parent-simple",
    "parent-undef",
    "unique-alias",
  ];

  public SchemaInvalidObjectsData()
  {
    foreach (string key in Keys) {
      Add(key);
    }
  }
}

public class SchemaInvalidSimpleData
  : TheoryData<string>
{
  public static readonly string[] Keys = [
    "domain-diff-kind",
    "domain-dup-alias",
    "domain-enum-none",
    "domain-enum-parent-unique",
    "domain-enum-undef",
    "domain-enum-undef-all",
    "domain-enum-undef-member",
    "domain-enum-undef-value",
    "domain-enum-unique",
    "domain-enum-unique-all",
    "domain-enum-unique-member",
    "domain-enum-wrong",
    "domain-number-parent",
    "domain-parent-self",
    "domain-parent-self-more",
    "domain-parent-self-parent",
    "domain-parent-self-recurse",
    "domain-parent-undef",
    "domain-parent-wrong-kind",
    "domain-parent-wrong-type",
    "domain-string-diff",
    "domain-string-parent",
    "enum-dup-alias",
    "enum-parent-alias-dup",
    "enum-parent-diff",
    "enum-parent-undef",
    "enum-parent-wrong",
    "union-more",
    "union-more-parent",
    "union-parent",
    "union-parent-more",
    "union-parent-recurse",
    "union-recurse",
    "union-recurse-parent",
    "union-self",
    "union-undef",
    "union-wrong",
    "unique-type-alias",
    "unique-types",
  ];

  public SchemaInvalidSimpleData()
  {
    foreach (string key in Keys) {
      Add(key);
    }
  }
}

public class SchemaValidGlobalsData
  : TheoryData<string>
{
  public static readonly string[] Keys = [
    "category-output",
    "category-output-dict",
    "category-output-list",
    "category-output-optional",
    "description",
    "description-backslash",
    "description-between",
    "description-complex",
    "description-double",
    "description-single",
    "directive-param-dict",
    "directive-param-in",
    "directive-param-list",
    "directive-param-opt",
    "option-setting",
  ];

  public SchemaValidGlobalsData()
  {
    foreach (string key in Keys) {
      Add(key);
    }
  }
}

public class SchemaValidMergesData
  : TheoryData<string>
{
  public static readonly string[] Keys = [
    "category",
    "category-alias",
    "category-mod",
    "directive",
    "directive-alias",
    "directive-param",
    "domain-alias",
    "domain-boolean",
    "domain-boolean-diff",
    "domain-boolean-same",
    "domain-enum-diff",
    "domain-enum-same",
    "domain-number",
    "domain-number-diff",
    "domain-number-same",
    "domain-string",
    "domain-string-diff",
    "domain-string-same",
    "enum-alias",
    "enum-diff",
    "enum-same",
    "enum-same-parent",
    "enum-value-alias",
    "object",
    "object-alias",
    "object-alt",
    "object-field",
    "object-field-alias",
    "object-param",
    "object-parent",
    "option",
    "option-alias",
    "option-value",
    "output-field-enum-alias",
    "output-field-enum-value",
    "output-field-param",
    "union-diff",
    "union-same",
  ];

  public SchemaValidMergesData()
  {
    foreach (string key in Keys) {
      Add(key);
    }
  }
}

public class SchemaValidObjectsData
  : TheoryData<string>
{
  public static readonly string[] Keys = [
    "alt",
    "alt-dual",
    "alt-mod-Boolean",
    "alt-mod-param",
    "alt-simple",
    "field",
    "field-dual",
    "field-mod-Enum",
    "field-mod-param",
    "field-object",
    "field-simple",
    "generic-alt",
    "generic-alt-arg",
    "generic-alt-dual",
    "generic-alt-param",
    "generic-alt-simple",
    "generic-dual",
    "generic-field",
    "generic-field-arg",
    "generic-field-dual",
    "generic-field-param",
    "generic-param",
    "generic-parent",
    "generic-parent-arg",
    "generic-parent-dual",
    "generic-parent-dual-parent",
    "generic-parent-param",
    "generic-parent-param-parent",
    "input-field-Enum",
    "input-field-null",
    "input-field-Number",
    "input-field-String",
    "output-field-enum",
    "output-field-enum-parent",
    "output-field-value",
    "output-generic-enum",
    "output-generic-value",
    "output-param",
    "output-param-mod-Domain",
    "output-param-mod-param",
    "output-parent-generic",
    "output-parent-param",
    "parent",
    "parent-alt",
    "parent-dual",
    "parent-field",
    "parent-param-diff",
    "parent-param-same",
  ];

  public SchemaValidObjectsData()
  {
    foreach (string key in Keys) {
      Add(key);
    }
  }
}

public class SchemaValidSimpleData
  : TheoryData<string>
{
  public static readonly string[] Keys = [
    "domain-enum-all",
    "domain-enum-all-parent",
    "domain-enum-member",
    "domain-enum-parent",
    "domain-enum-unique",
    "domain-enum-unique-parent",
    "domain-enum-value",
    "domain-enum-value-parent",
    "domain-number-parent",
    "domain-parent",
    "domain-string-parent",
    "enum-parent",
    "enum-parent-alias",
    "enum-parent-dup",
    "union-parent",
  ];

  public SchemaValidSimpleData()
  {
    foreach (string key in Keys) {
      Add(key);
    }
  }
}
