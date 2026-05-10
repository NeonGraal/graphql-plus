//HintName: test_-Global_Enc.gen.cs
// Generated from {CurrentDirectory}-Global.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Global;

internal class test_AndTypeEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_AndTypeObject>
{
  private readonly DeferOne<IEncoder<Itest_NamedObject>> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly DeferOne<IEncoder<Itest_Type>> _itest_Type = encoders.EncoderFor<Itest_Type>();
  public Structured Encode(Itest_AndTypeObject input)
    => _itest_Named.I.Encode(input)
      .AddEncoded("type", input.Type, _itest_Type.I);

  internal static test_AndTypeEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_CategoriesEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_CategoriesObject>
{
  private readonly DeferOne<IEncoder<Itest_AndTypeObject>> _itest_AndType = encoders.EncoderFor<Itest_AndTypeObject>();
  private readonly DeferOne<IEncoder<Itest_Category>> _itest_Category = encoders.EncoderFor<Itest_Category>();
  public Structured Encode(Itest_CategoriesObject input)
    => _itest_AndType.I.Encode(input)
      .AddEncoded("category", input.Category, _itest_Category.I);

  internal static test_CategoriesEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_CategoryEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_CategoryObject>
{
  private readonly DeferOne<IEncoder<Itest_AliasedObject>> _itest_Aliased = encoders.EncoderFor<Itest_AliasedObject>();
  private readonly DeferOne<IEncoder<Itest_TypeRef<Itest_TypeKind>>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRef<Itest_TypeKind>>();
  private readonly DeferOne<IEncoder<Itest_Modifiers>> _itest_Modifiers = encoders.EncoderFor<Itest_Modifiers>();
  public Structured Encode(Itest_CategoryObject input)
    => _itest_Aliased.I.Encode(input)
      .AddEnum("resolution", input.Resolution)
      .AddEncoded("output", input.Output, _itest_TypeRef.I)
      .AddList("modifiers", input.Modifiers, _itest_Modifiers.I);

  internal static test_CategoryEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_ResolutionEncoder : IEncoder<test_Resolution>
{
  public Structured Encode(test_Resolution input)
    => input.EncodeEnum("_Resolution");

  internal static test_ResolutionEncoder Factory(IEncoderRepository _) => new();
}

internal class test_DirectivesEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DirectivesObject>
{
  private readonly DeferOne<IEncoder<Itest_AndTypeObject>> _itest_AndType = encoders.EncoderFor<Itest_AndTypeObject>();
  private readonly DeferOne<IEncoder<Itest_Directive>> _itest_Directive = encoders.EncoderFor<Itest_Directive>();
  public Structured Encode(Itest_DirectivesObject input)
    => _itest_AndType.I.Encode(input)
      .AddEncoded("directive", input.Directive, _itest_Directive.I);

  internal static test_DirectivesEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_DirectiveEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DirectiveObject>
{
  private readonly DeferOne<IEncoder<Itest_AliasedObject>> _itest_Aliased = encoders.EncoderFor<Itest_AliasedObject>();
  private readonly DeferOne<IEncoder<Itest_InputFieldType>> _itest_InputFieldType = encoders.EncoderFor<Itest_InputFieldType>();
  public Structured Encode(Itest_DirectiveObject input)
    => _itest_Aliased.I.Encode(input)
      .AddEncoded("parameter", input.Parameter, _itest_InputFieldType.I)
      .Add("repeatable", input.Repeatable.Encode());

  internal static test_DirectiveEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_LocationEncoder : IEncoder<test_Location>
{
  public Structured Encode(test_Location input)
    => input.EncodeEnum("_Location");

  internal static test_LocationEncoder Factory(IEncoderRepository _) => new();
}

internal class test_SettingEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_SettingObject>
{
  private readonly DeferOne<IEncoder<Itest_NamedObject>> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly DeferOne<IEncoder<GqlpValue>> _gqlpValue = encoders.EncoderFor<GqlpValue>();
  public Structured Encode(Itest_SettingObject input)
    => _itest_Named.I.Encode(input)
      .AddEncoded("value", input.Value, _gqlpValue.I);

  internal static test_SettingEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test__GlobalEncoders
{
  internal static IEncoderRepositoryBuilder Addtest__GlobalEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_AndTypeObject>(test_AndTypeEncoder.Factory)
      .AddEncoder<Itest_CategoriesObject>(test_CategoriesEncoder.Factory)
      .AddEncoder<Itest_CategoryObject>(test_CategoryEncoder.Factory)
      .AddEncoder<test_Resolution>(test_ResolutionEncoder.Factory)
      .AddEncoder<Itest_DirectivesObject>(test_DirectivesEncoder.Factory)
      .AddEncoder<Itest_DirectiveObject>(test_DirectiveEncoder.Factory)
      .AddEncoder<test_Location>(test_LocationEncoder.Factory)
      .AddEncoder<Itest_SettingObject>(test_SettingEncoder.Factory);
}
