namespace GqlPlus.Schema.Modelling.Globals;

public class SchModifierModellerTests
  : SchModellerClassTestBase<IAstModifier, ISch_Modifiers>
{
  protected override IModeller<IAstModifier, ISch_Modifiers> Modeller { get; } = new SchModifierModeller();

  [Fact]
  public void ToModel_OptionalModifier_ReturnsOptionalDiscriminator()
  {
    IAstModifier ast = A.Modifier(ModifierKind.Opt);

    ISch_Modifiers result = Modeller.ToModel(ast, TypeKinds);

    result.As_ModifierKindOptional.ShouldNotBeNull();
  }

  [Fact]
  public void ToModel_DictionaryModifier_ReturnsDictionaryDiscriminator()
  {
    IAstModifier ast = A.Error<IAstModifier>();
    ast.ModifierKind.Returns(ModifierKind.Dict);
    ast.Key.Returns("ItemKey");
    ast.IsOptional.Returns(true);
    TypeKindIs("ItemKey", GqlpTypeKind.Enum);

    ISch_Modifiers result = Modeller.ToModel(ast, TypeKinds);
    ISch_Collections collections = result.As_Collections.ShouldNotBeNull();

    collections.As_ModifierKindDictionary.ShouldNotBeNull();
  }
}
