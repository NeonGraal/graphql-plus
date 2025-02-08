// Generated from .\test\GqlPlus.ComponentTestBase\Samples\Schema
// Collected from 5e5c83d  (HEAD -> union-tests, origin/yaml, origin/main, origin/json, origin/include, origin/HEAD, main) 2024-09-24 Merge pull request #3 from graphql-plus/samples


namespace GqlPlus;

public class SchemaInvalidGlobalsData
  : TheoryData<string>
{
  public SchemaInvalidGlobalsData()
  {
    Add("bad-parse");
    Add("category-diff-mod");
    Add("category-dup-alias");
    Add("category-duplicate");
    Add("category-output-generic");
    Add("category-output-mod-param");
    Add("category-output-undef");
    Add("category-output-wrong");
    Add("directive-diff-option");
    Add("directive-diff-param");
    Add("directive-no-param");
    Add("directive-param-mod-param");
    Add("option-diff-name");
  }
}

public class SchemaInvalidObjectsData
  : TheoryData<string>
{
  public SchemaInvalidObjectsData()
  {
    Add("alt-diff-mod");
    Add("alt-mod-undef");
    Add("alt-mod-undef-param");
    Add("alt-mod-wrong");
    Add("alt-more");
    Add("alt-recurse");
    Add("alt-self");
    Add("alt-simple-param");
    Add("dual-alt-input");
    Add("dual-alt-output");
    Add("dual-alt-param-input");
    Add("dual-alt-param-output");
    Add("dual-field-input");
    Add("dual-field-output");
    Add("dual-field-param-input");
    Add("dual-field-param-output");
    Add("dual-parent-input");
    Add("dual-parent-output");
    Add("dual-parent-param-input");
    Add("dual-parent-param-output");
    Add("field-alias");
    Add("field-diff-mod");
    Add("field-diff-type");
    Add("field-mod-undef");
    Add("field-mod-undef-param");
    Add("field-mod-wrong");
    Add("field-simple-param");
    Add("generic-alt-undef");
    Add("generic-arg-less");
    Add("generic-arg-more");
    Add("generic-arg-undef");
    Add("generic-field-undef");
    Add("generic-param-undef");
    Add("generic-parent-less");
    Add("generic-parent-more");
    Add("generic-parent-undef");
    Add("generic-unused");
    Add("input-alt-output");
    Add("input-field-null");
    Add("input-field-output");
    Add("input-parent-output");
    Add("output-alt-input");
    Add("output-enum-bad");
    Add("output-enum-diff");
    Add("output-enumValue-bad");
    Add("output-enumValue-wrong");
    Add("output-field-input");
    Add("output-generic-enum-bad");
    Add("output-generic-enum-wrong");
    Add("output-param-diff");
    Add("output-param-mod-undef");
    Add("output-param-mod-undef-param");
    Add("output-param-mod-wrong");
    Add("output-param-undef");
    Add("output-parent-input");
    Add("parent-alt-mod");
    Add("parent-alt-more");
    Add("parent-alt-recurse");
    Add("parent-alt-self");
    Add("parent-alt-self-more");
    Add("parent-alt-self-recurse");
    Add("parent-field-alias");
    Add("parent-field-alias-more");
    Add("parent-field-alias-recurse");
    Add("parent-field-mod");
    Add("parent-field-mod-more");
    Add("parent-field-mod-recurse");
    Add("parent-more");
    Add("parent-recurse");
    Add("parent-self");
    Add("parent-self-alt");
    Add("parent-self-alt-more");
    Add("parent-self-alt-recurse");
    Add("parent-simple");
    Add("parent-undef");
    Add("unique-alias");
  }
}

public class SchemaInvalidSimpleData
  : TheoryData<string>
{
  public SchemaInvalidSimpleData()
  {
    Add("domain-diff-kind");
    Add("domain-dup-alias");
    Add("domain-enum-none");
    Add("domain-enum-parent-unique");
    Add("domain-enum-undef");
    Add("domain-enum-undef-all");
    Add("domain-enum-undef-member");
    Add("domain-enum-undef-value");
    Add("domain-enum-unique");
    Add("domain-enum-unique-all");
    Add("domain-enum-unique-member");
    Add("domain-enum-wrong");
    Add("domain-number-parent");
    Add("domain-parent-self");
    Add("domain-parent-self-more");
    Add("domain-parent-self-parent");
    Add("domain-parent-self-recurse");
    Add("domain-parent-undef");
    Add("domain-parent-wrong-kind");
    Add("domain-parent-wrong-type");
    Add("domain-string-diff");
    Add("domain-string-parent");
    Add("enum-dup-alias");
    Add("enum-parent-alias-dup");
    Add("enum-parent-diff");
    Add("enum-parent-undef");
    Add("enum-parent-wrong");
    Add("union-dup-alias");
    Add("union-more");
    Add("union-more-parent");
    Add("union-parent");
    Add("union-parent-more");
    Add("union-parent-recurse");
    Add("union-recurse");
    Add("union-recurse-parent");
    Add("union-self");
    Add("union-undef");
    Add("union-wrong");
    Add("unique-type-alias");
    Add("unique-types");
  }
}

public class SchemaValidGlobalsData
  : TheoryData<string>
{
  public SchemaValidGlobalsData()
  {
    Add("category-output");
    Add("category-output-dict");
    Add("category-output-list");
    Add("category-output-optional");
    Add("description");
    Add("description-backslash");
    Add("description-between");
    Add("description-complex");
    Add("description-double");
    Add("description-single");
    Add("directive-param-dict");
    Add("directive-param-in");
    Add("directive-param-list");
    Add("directive-param-opt");
    Add("option-setting");
  }
}

public class SchemaValidMergesData
  : TheoryData<string>
{
  public SchemaValidMergesData()
  {
    Add("category");
    Add("category-alias");
    Add("category-mod");
    Add("directive");
    Add("directive-alias");
    Add("directive-param");
    Add("domain-alias");
    Add("domain-boolean");
    Add("domain-boolean-diff");
    Add("domain-boolean-same");
    Add("domain-enum-diff");
    Add("domain-enum-same");
    Add("domain-number");
    Add("domain-number-diff");
    Add("domain-number-same");
    Add("domain-string");
    Add("domain-string-diff");
    Add("domain-string-same");
    Add("enum-alias");
    Add("enum-diff");
    Add("enum-same");
    Add("enum-same-parent");
    Add("enum-value-alias");
    Add("object");
    Add("object-alias");
    Add("object-alt");
    Add("object-field");
    Add("object-field-alias");
    Add("object-param");
    Add("object-parent");
    Add("option");
    Add("option-alias");
    Add("option-value");
    Add("output-field-enum-alias");
    Add("output-field-enum-value");
    Add("output-field-param");
    Add("union-alias");
    Add("union-diff");
    Add("union-same");
  }
}

public class SchemaValidObjectsData
  : TheoryData<string>
{
  public SchemaValidObjectsData()
  {
    Add("alt");
    Add("alt-dual");
    Add("alt-mod-Boolean");
    Add("alt-mod-param");
    Add("alt-simple");
    Add("field");
    Add("field-dual");
    Add("field-mod-Enum");
    Add("field-mod-param");
    Add("field-object");
    Add("field-simple");
    Add("generic-alt");
    Add("generic-alt-arg");
    Add("generic-alt-dual");
    Add("generic-alt-param");
    Add("generic-alt-simple");
    Add("generic-dual");
    Add("generic-field");
    Add("generic-field-arg");
    Add("generic-field-dual");
    Add("generic-field-param");
    Add("generic-param");
    Add("generic-parent");
    Add("generic-parent-arg");
    Add("generic-parent-dual");
    Add("generic-parent-dual-parent");
    Add("generic-parent-param");
    Add("generic-parent-param-parent");
    Add("input-field-Enum");
    Add("input-field-null");
    Add("input-field-Number");
    Add("input-field-String");
    Add("output-field-enum");
    Add("output-field-enum-parent");
    Add("output-field-value");
    Add("output-generic-enum");
    Add("output-generic-value");
    Add("output-param");
    Add("output-param-mod-Domain");
    Add("output-param-mod-param");
    Add("output-parent-generic");
    Add("output-parent-param");
    Add("parent");
    Add("parent-alt");
    Add("parent-dual");
    Add("parent-field");
    Add("parent-param-diff");
    Add("parent-param-same");
  }
}

public class SchemaValidSimpleData
  : TheoryData<string>
{
  public SchemaValidSimpleData()
  {
    Add("domain-enum-all");
    Add("domain-enum-all-parent");
    Add("domain-enum-member");
    Add("domain-enum-parent");
    Add("domain-enum-unique");
    Add("domain-enum-unique-parent");
    Add("domain-enum-value");
    Add("domain-enum-value-parent");
    Add("domain-number-parent");
    Add("domain-parent");
    Add("domain-string-parent");
    Add("enum-parent");
    Add("enum-parent-alias");
    Add("enum-parent-dup");
    Add("union-parent");
  }
}
