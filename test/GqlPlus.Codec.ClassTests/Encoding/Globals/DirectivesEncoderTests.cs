﻿namespace GqlPlus.Encoding.Globals;

public class DirectivesEncoderTests
  : EncoderClassTestBase<DirectivesModel>
{
  public DirectivesEncoderTests()
  {
    _directive = RFor<DirectiveModel>();
    _baseType = RFor<BaseTypeModel>();
    Encoder = new DirectivesEncoder(new(_directive, _baseType));
  }

  private readonly IEncoder<DirectiveModel> _directive;
  private readonly IEncoder<BaseTypeModel> _baseType;

  protected override IEncoder<DirectivesModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidDirectivesModel_ReturnsStructured(string name)
  {
    // Arrange
    BaseTypeModel type = new TypeInputModel(name, "");
    DirectiveModel directive = new(name, "");
    _baseType.Encode(type).Returns(new Structured(name, "Input"));
    _directive.Encode(directive).Returns(new Structured(name, "Directive"));

    // Act
    EncodeAndCheck(new() {
      Type = type,
      And = directive
    }, [
        "!_Directives",
        "directive: !Directive " + name,
        "type: !Input " + name
        ]);
  }
}
