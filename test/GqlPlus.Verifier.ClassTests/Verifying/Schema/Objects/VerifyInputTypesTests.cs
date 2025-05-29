﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyInputTypesTests
  : ObjectVerifierTestsBase<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate, IGqlpInputArg>
{
  private readonly IGqlpInputObject _input;

  protected override IGqlpInputObject TheObject => _input;
  protected override IVerifyUsage<IGqlpInputObject> Verifier { get; }

  public VerifyInputTypesTests()
  {
    Verifier = new VerifyInputTypes(new(Aliased.Intf, MergeFields.Intf, MergeAlternates.Intf, ConstraintDelegate, LoggerFactory));

    _input = NFor<IGqlpInputObject>("Input");
  }

  [Fact]
  public void Verify_Input_WithFieldNullDefault_ReturnsError()
  {
    Define<IGqlpInputObject>("b");

    IGqlpFieldKey nullLabel = EFor<IGqlpFieldKey>();
    nullLabel.EnumValue.Returns("Null.null");

    IGqlpConstant nullValue = EFor<IGqlpConstant>();
    nullValue.Value.Returns(nullLabel);

    IGqlpInputBase inType = NFor<IGqlpInputBase>("b");
    IGqlpInputField field = NFor<IGqlpInputField>("a");
    SetFieldType(field, inType);
    field.DefaultValue.Returns(nullValue);

    _input.Fields.Returns([field]);
    _input.ObjFields.Returns([field]);

    Usages.Add(_input);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Input_WithOptionalFieldNullDefault_ReturnsNoErrors()
  {
    Define<IGqlpInputObject>("b");

    IGqlpFieldKey nullLabel = EFor<IGqlpFieldKey>();
    nullLabel.EnumValue.Returns("Null.null");

    IGqlpConstant nullValue = EFor<IGqlpConstant>();
    nullValue.Value.Returns(nullLabel);

    IGqlpInputBase inType = NFor<IGqlpInputBase>("b");
    IGqlpInputField field = NFor<IGqlpInputField>("a");
    SetFieldType(field, inType);
    field.DefaultValue.Returns(nullValue);
    IGqlpModifier optional = EFor<IGqlpModifier>();
    optional.ModifierKind.Returns(ModifierKind.Optional);
    field.Modifiers.Returns([optional]);

    _input.Fields.Returns([field]);
    _input.ObjFields.Returns([field]);

    Usages.Add(_input);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }
}
