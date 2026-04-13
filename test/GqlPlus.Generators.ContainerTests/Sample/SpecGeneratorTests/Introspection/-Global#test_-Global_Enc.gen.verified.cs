//HintName: test_-Global_Enc.gen.cs
// Generated from {CurrentDirectory}-Global.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Global;

internal class test_AndTypeEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_AndTypeObject>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly IEncoder<Itest_Type> _itest_Type = encoders.EncoderFor<Itest_Type>();
  public Structured Encode(Itest_AndTypeObject input)
    => _itest_Named.Encode(input)
      .AddEncoded("type", input.Type, _itest_Type);
}

internal class test_CategoriesEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_CategoriesObject>
{
  private readonly IEncoder<Itest_AndTypeObject> _itest_AndType = encoders.EncoderFor<Itest_AndTypeObject>();
  private readonly IEncoder<Itest_Category> _itest_Category = encoders.EncoderFor<Itest_Category>();
  public Structured Encode(Itest_CategoriesObject input)
    => _itest_AndType.Encode(input)
      .AddEncoded("category", input.Category, _itest_Category);
}

internal class test_CategoryEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_CategoryObject>
{
  private readonly IEncoder<Itest_AliasedObject> _itest_Aliased = encoders.EncoderFor<Itest_AliasedObject>();
  private readonly IEncoder<Itest_TypeRef<Itest_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRef<Itest_TypeKind>>();
  private readonly IEncoder<Itest_Modifiers> _itest_Modifiers = encoders.EncoderFor<Itest_Modifiers>();
  public Structured Encode(Itest_CategoryObject input)
    => _itest_Aliased.Encode(input)
      .AddEnum("resolution", input.Resolution)
      .AddEncoded("output", input.Output, _itest_TypeRef)
      .AddList("modifiers", input.Modifiers, _itest_Modifiers);
}

internal class test_ResolutionEncoder : IEncoder<test_Resolution>
{
  public Structured Encode(test_Resolution input)
    => new(input.ToString(), "_Resolution");
}

internal class test_DirectivesEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DirectivesObject>
{
  private readonly IEncoder<Itest_AndTypeObject> _itest_AndType = encoders.EncoderFor<Itest_AndTypeObject>();
  private readonly IEncoder<Itest_Directive> _itest_Directive = encoders.EncoderFor<Itest_Directive>();
  public Structured Encode(Itest_DirectivesObject input)
    => _itest_AndType.Encode(input)
      .AddEncoded("directive", input.Directive, _itest_Directive);
}

internal class test_DirectiveEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DirectiveObject>
{
  private readonly IEncoder<Itest_AliasedObject> _itest_Aliased = encoders.EncoderFor<Itest_AliasedObject>();
  private readonly IEncoder<Itest_InputFieldType> _itest_InputFieldType = encoders.EncoderFor<Itest_InputFieldType>();
  public Structured Encode(Itest_DirectiveObject input)
    => _itest_Aliased.Encode(input)
      .AddEncoded("parameter", input.Parameter, _itest_InputFieldType)
      .Add("repeatable", input.Repeatable);
}

internal class test_LocationEncoder : IEncoder<test_Location>
{
  public Structured Encode(test_Location input)
    => new(input.ToString(), "_Location");
}

internal class test_SettingEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_SettingObject>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly IEncoder<GqlpValue> _gqlpValue = encoders.EncoderFor<GqlpValue>();
  public Structured Encode(Itest_SettingObject input)
    => _itest_Named.Encode(input)
      .AddEncoded("value", input.Value, _gqlpValue);
}
