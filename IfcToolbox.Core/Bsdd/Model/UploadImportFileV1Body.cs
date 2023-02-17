/* 
 * bSDD API prototype
 *
 * API to access the buildingSMART Data Dictionary
 *
 * OpenAPI spec version: v1
 * Contact: bsdd_support@buildingsmart.org
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// UploadImportFileV1Body
    /// </summary>
    [DataContract]
        public partial class UploadImportFileV1Body :  IEquatable<UploadImportFileV1Body>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UploadImportFileV1Body" /> class.
        /// </summary>
        /// <param name="organizationCode">Code of the organization owning the domain.  If you do not know the code, contact us (see e-mail address on top of this page) (required).</param>
        /// <param name="formFile">The bsdd import file in json format (required).</param>
        /// <param name="validateOnly">Set to true if you only want to validate the file. Even when there are no validation errors the file wil not be imported.  The validation result will not be send via e-mail..</param>
        public UploadImportFileV1Body(string organizationCode = default(string), byte[] formFile = default(byte[]), bool? validateOnly = default(bool?))
        {
            // to ensure "organizationCode" is required (not null)
            if (organizationCode == null)
            {
                throw new InvalidDataException("organizationCode is a required property for UploadImportFileV1Body and cannot be null");
            }
            else
            {
                this.OrganizationCode = organizationCode;
            }
            // to ensure "formFile" is required (not null)
            if (formFile == null)
            {
                throw new InvalidDataException("formFile is a required property for UploadImportFileV1Body and cannot be null");
            }
            else
            {
                this.FormFile = formFile;
            }
            this.ValidateOnly = validateOnly;
        }
        
        /// <summary>
        /// Code of the organization owning the domain.  If you do not know the code, contact us (see e-mail address on top of this page)
        /// </summary>
        /// <value>Code of the organization owning the domain.  If you do not know the code, contact us (see e-mail address on top of this page)</value>
        [DataMember(Name="OrganizationCode", EmitDefaultValue=false)]
        public string OrganizationCode { get; set; }

        /// <summary>
        /// The bsdd import file in json format
        /// </summary>
        /// <value>The bsdd import file in json format</value>
        [DataMember(Name="FormFile", EmitDefaultValue=false)]
        public byte[] FormFile { get; set; }

        /// <summary>
        /// Set to true if you only want to validate the file. Even when there are no validation errors the file wil not be imported.  The validation result will not be send via e-mail.
        /// </summary>
        /// <value>Set to true if you only want to validate the file. Even when there are no validation errors the file wil not be imported.  The validation result will not be send via e-mail.</value>
        [DataMember(Name="ValidateOnly", EmitDefaultValue=false)]
        public bool? ValidateOnly { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UploadImportFileV1Body {\n");
            sb.Append("  OrganizationCode: ").Append(OrganizationCode).Append("\n");
            sb.Append("  FormFile: ").Append(FormFile).Append("\n");
            sb.Append("  ValidateOnly: ").Append(ValidateOnly).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as UploadImportFileV1Body);
        }

        /// <summary>
        /// Returns true if UploadImportFileV1Body instances are equal
        /// </summary>
        /// <param name="input">Instance of UploadImportFileV1Body to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UploadImportFileV1Body input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.OrganizationCode == input.OrganizationCode ||
                    (this.OrganizationCode != null &&
                    this.OrganizationCode.Equals(input.OrganizationCode))
                ) && 
                (
                    this.FormFile == input.FormFile ||
                    (this.FormFile != null &&
                    this.FormFile.Equals(input.FormFile))
                ) && 
                (
                    this.ValidateOnly == input.ValidateOnly ||
                    (this.ValidateOnly != null &&
                    this.ValidateOnly.Equals(input.ValidateOnly))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.OrganizationCode != null)
                    hashCode = hashCode * 59 + this.OrganizationCode.GetHashCode();
                if (this.FormFile != null)
                    hashCode = hashCode * 59 + this.FormFile.GetHashCode();
                if (this.ValidateOnly != null)
                    hashCode = hashCode * 59 + this.ValidateOnly.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}