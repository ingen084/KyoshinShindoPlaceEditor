# KyoshinShindoPlaceEditor

���k���j�^�̐F���擾����s�N�Z�����W��ϊ��E�ҏW����A�v���P�[�V�����ł��B

## �{�̂̃\�[�X�R�[�h��ǂޑO��
���̃A�v���P�[�V�����͖ړI�̂��߂ɊJ�����ꂽ���߁A�ǐ���傫�������Ă��܂��B�ǂލۂ͐S���ēǂ�ŉ������B

## �r���h�ɕK�v�Ȃ���
- .NET Framework 4.6.2
- VS2017(����ȊO�ł͖��m�F)

## �`���[�g���A��
����̋��k���j�^�̉摜����ɂ��Ă͋��k���j�^�摜�E���`?`�{�^�����Q�Ƃ��Ă��������B

���̃`���[�g���A���ł͂Ƃ肠����NIED�̊ϑ��_����CSV�f�[�^����x�[�X�𐶐����AEqWatch�̃f�[�^���C���|�[�g����Ƃ���܂ł�������܂��B

���������������ꍇ��A������~�����ꍇ�͉��L��FAQ���Q�l�ɂ��Ă��������B

1. �Ƃ肠�����N�����܂��B�E���X�g�ɂ͉��������͂��ł��B
2. �܂���NIED�̃f�[�^���C���|�[�g���Ă݂܂��傤�B NIED�̃y�[�W( http://www.kyoshin.bosai.go.jp/kyoshin/db/index.html?all )�̏㕔�ɂ���A`�ϑ��_�ꗗ(CSV�t�@�C��)�́A������i K-NET&KiK-net�AK-NET�A KiK-net�j���N���b�N���ă_�E�����[�h�ł��܂��B`�́A`K-NET`�A`KiK-net`���ʂɃ_�E�����[�h���A **���̃A�v���P�[�V�����̃f�B���N�g��** �ɔz�u���܂��B
3. �E��̃��j���[����`NIED�̊ϑ��_��񂩂�C���|�[�g`�������Ă��������B�t�@�C�������݂��Ȃ��ꍇ�̓G���[���\������܂��B�����Ŏ��s����ꍇ�́A�o�O�������͕s���ȃt�@�C����ǂݍ��܂��Ă���\��������܂��B������x�m�F���Ă��������B
4. ����ɃC���|�[�g����Ă��邱�Ƃ��m�F�ł�����A����EqWatch�̃f�[�^���C���|�[�g���Ă݂܂��傤�B
5. �܂��A`EqWatch.exe`�Ɠ����f�B���N�g���ɂ���`Kansokuten.dat`�� **���̃A�v���P�[�V�����̃f�B���N�g��** �� **�R�s�[** ���Ă��������B(���̂��ƕҏW���邽�߂ł�)
6. **�R�s�[��̃t�@�C����** �K���ȃe�L�X�g�G�f�B�^�ŊJ�������ƁA���ׂĂ�`�G�C`��`���C`�ɒu�������Ă��������B(�]�k:�G�C�s�͒����̓s�s)
7. �ۑ��������ƁA�E���`EqWatch����C���|�[�g`�������Ă��������B
8. ���܂��s���Βǉ�0��(�X�V�̂�)�ɂȂ�͂��ł����A��񂪍X�V�Ȃǂ���Ă����ꍇ�͂��̌���ł͂���܂���B
9. �Y��������ꏊ���Ȃ�������̃}�b�v���`�F�b�N���āA(�E�̃��X�g�̍��ڂ�I������ƍ����̃}�b�v�ɐԓ_���\�������̂ŏꏊ�m�F�ɕ֗��ł��B�}�b�v�͉E�h���b�O�ňړ��ł��܂��B)�K�x�C�����Ă��������B(���ɉ������)

- **�ۑ��{�^���������Ȃ��ƕۑ�����܂���B** �I������O�ɂ͕K���ۑ�����悤�ɂ��Ă����܂��傤�B�ۑ��E�ǂݍ��݂͏チ�j���[��`�t�@�C��(F)`���ɂ���܂��B

## pbf�t�@�C����csv�t�@�C���̈Ⴂ
### pbf
�t�@�C���T�C�Y�������������Ȃ�܂��B�ǂݍ��݂����ɍ����ł��B(�܂��Ȃ�����).proto�t�@�C��������Ηl�X�Ȍ���Œ��ڗ��p���邱�Ƃ��ł��܂��B

### csv
�����x�[�X�ɂȂ邽�߃t�@�C���T�C�Y�������傫���Ȃ�܂����A�ǂ̃A�v���P�[�V�����ł��ȒP�ɏ������邱�Ƃ��ł��܂��B

## �ۑ������t�@�C���̎g�p���@
pbf�`���ɂĕۑ������t�@�C����ǂݍ��ލۂɂ�`ReadDataExample`���Q�Ƃ��Ă��������B

`Program.cs`�ɏd�v�Ȃ��Ƃ͑�̏����Ă���܂��B(.proto�����ĂȂ��ăX�~�}�Z���I)

csv�`���ŕۑ������t�@�C���̏o�͌`���́A

`�������Ă���l�b�g���[�N�̎��(0=�s��,1=KiK-net,2=K-NET),�n�_�R�[�h,�x�~(����)��Ԃɂ��邩�ǂ���(True/False),�ϑ��n�_��,�ϑ��n�_��������n��̖���,�ܓx,�o�x,���k���j�^��ł�X���W,���k���j�^��ł�Y���W`

�ƂȂ��Ă��܂��B���k���j�^��ł̍��W���Ȃ��ꍇ�AX,Y���ɋ�ɂȂ�܂��B�蓮����������p�ɍ���Ă��܂��B

## ���p�ɂ���
���̃A�v���P�[�V�����ō쐬�����t�@�C�����A�v���P�[�V�����Ɏg�p����ۂ͂ł��邾��(�l�ł������p���Ȃ��Ƃ��Ă��񍐂��Ă���������Ί�т܂�)���(@ingen084)�ɕ񍐂��Ă��������B�N���W�b�g�\�L�͔C�ӂł��B

���̃A�v���P�[�V������Y�t���Ĕz�z�Ȃǂ͗v���k�ł��肢���܂��B

�Ƃ������AKyoshinShindoPlaceEditor�̃\�[�X�̕��͂��܂�ɂ��N�\������̂Ŏg��Ȃ��ق��������ł��B�}�W��(�}�W��)

�T���v���v���W�F�N�g��`PbfClass`�t�H���_�̒��ɓ����Ă���N���X�Q�͎��R�Ɏg�p���Ă��������B

�������A���O��Ԃ�N���X���A�v���p�e�B���̕ύX�Ȃǂ͂����R�ɂǂ����B

�ۑ������t�@�C���̊g���q��ύX���Ďg�p���Ă邱�Ƃ��C�Â����Ȃ��悤�Ȃ��Ƃ��\�ł��B

## �ݒ�
`KyoshinShindoPlaceEditor.exe.config`��ҏW���܂��B
```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <configSections>
        <sectionGroup name="applicationSettings" type="System.Configuration.ApplicationSettingsGroup, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" >
            <section name="KyoshinShindoPlaceEditor.Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
        </sectionGroup>
    </configSections>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.2" />
    </startup>
    <applicationSettings>
        <KyoshinShindoPlaceEditor.Properties.Settings>
            <setting name="PbfFilename" serializeAs="String">
                <value>[�ǂݍ���pbf�t�@�C���̃p�X]</value>
            </setting>
            <setting name="CsvFilename" serializeAs="String">
                <value>[�ǂݍ���csv�t�@�C���̃p�X]</value>
            </setting>
        </KyoshinShindoPlaceEditor.Properties.Settings>
    </applicationSettings>
</configuration>
```
������`[�ǂݍ���pbf�t�@�C���̃p�X]` `[�ǂݍ���pbf�t�@�C���̃p�X]`��ҏW���邱�ƂŁA�ǂݍ��݃{�^�����������ۂɓǂݍ��܂��t�@�C����ύX���邱�Ƃ��ł��܂��B

��΁E���΃p�X���ɗ��p�ł��܂��̂ŁA���񊈗p���Ă��������B

## FAQ
### �g�����킩��˂�
���̒ʂ�K�o�K�o����Ȃ̂łȂ�ł������Ă��������B

### ������
���\�G���[�����K���Ȃ̂�
�󋵂������Ă���邩�f�o�b�O���Ă����Ə�����܂��B

### �v�����N�ł��Ȃ��񂾂��ǁH
����GitHub�ɏグ��\�����������Ȃ̂ł���܂ł�Twitter��DM���Ȃ񂩂ł�낵�����肢���܂��B

### �Ȃ�₱�̃N�\�[�X �A�z�����B���߂��炱�̎d��?
�킩��